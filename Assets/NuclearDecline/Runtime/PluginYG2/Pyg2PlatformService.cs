using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace NuclearDecline
{
    public sealed class Pyg2PlatformService : IPlatformService
    {
        private readonly Pyg2AdsService ads = new Pyg2AdsService();
        private readonly Pyg2SaveService saves = new Pyg2SaveService();
        private readonly Pyg2LocalizationService localization = new Pyg2LocalizationService();
        private readonly Pyg2LeaderboardService leaderboards = new Pyg2LeaderboardService();

        public event Action OnReady;

        public bool IsReady { get; private set; }
        public bool IsInitialized { get; private set; }
        public string PlatformName => "PluginYG2:" + YG2.platform;
        public string PlayerId => YG2.player != null ? YG2.player.id : string.Empty;

        public IAdsService Ads => ads;
        public ILocalizationService Localization => localization;
        public ILeaderboardService Leaderboards => leaderboards;
        public ISaveService Saves => saves;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Register()
        {
            GamePlatformBridge.Initialize(new Pyg2PlatformService());
        }

        public void Initialize()
        {
            if (IsInitialized)
                return;

            IsInitialized = true;
            localization.Initialize();

            if (YG2.isSDKEnabled)
            {
                MarkReady();
            }
            else
            {
                YG2.onGetSDKData += MarkReady;
            }
        }

        public void GameReady()
        {
            YG2.GameReadyAPI();
        }

        public void GameplayStart()
        {
            YG2.GameplayStart();
        }

        public void GameplayStop()
        {
            YG2.GameplayStop();
        }

        private void MarkReady()
        {
            YG2.onGetSDKData -= MarkReady;
            saves.Load();
            localization.SyncFromSdk();

            if (IsReady)
                return;

            IsReady = true;
            OnReady?.Invoke();
        }
    }

    public sealed class Pyg2AdsService : IAdsService
    {
        private Action<AdResult> interstitialCallback;
        private readonly Dictionary<string, Action<AdResult>> rewardedCallbacks = new Dictionary<string, Action<AdResult>>();

        public bool IsInterstitialAvailable => !YG2.nowAdsShow && YG2.isTimerAdvCompleted;
        public bool IsRewardedAvailable => !YG2.nowAdsShow;

        public Pyg2AdsService()
        {
            EnsureSubscribed();
        }

        public void EnsureSubscribed()
        {
            YG2.onCloseInterAdvWasShow -= HandleInterstitialClosed;
            YG2.onErrorInterAdv -= HandleInterstitialError;
            YG2.onRewardAdv -= HandleRewardedSuccess;
            YG2.onCloseRewardedAdv -= HandleRewardedClosed;
            YG2.onErrorRewardedAdv -= HandleRewardedError;

            YG2.onCloseInterAdvWasShow += HandleInterstitialClosed;
            YG2.onErrorInterAdv += HandleInterstitialError;
            YG2.onRewardAdv += HandleRewardedSuccess;
            YG2.onCloseRewardedAdv += HandleRewardedClosed;
            YG2.onErrorRewardedAdv += HandleRewardedError;
        }

        public void ShowInterstitial(Action<AdResult> onComplete = null)
        {
            EnsureSubscribed();

            if (!IsInterstitialAvailable)
            {
                onComplete?.Invoke(AdResult.SkippedResult("interstitial"));
                return;
            }

            interstitialCallback = onComplete;
            YG2.InterstitialAdvShow();
        }

        public void ShowRewarded(string placementId, Action<AdResult> onComplete = null)
        {
            EnsureSubscribed();

            if (string.IsNullOrEmpty(placementId))
                placementId = "default";

            if (!IsRewardedAvailable)
            {
                onComplete?.Invoke(AdResult.SkippedResult(placementId));
                return;
            }

            rewardedCallbacks[placementId] = onComplete;
            YG2.RewardedAdvShow(placementId);
        }

        private void HandleInterstitialClosed(bool wasShown)
        {
            Action<AdResult> callback = interstitialCallback;
            interstitialCallback = null;
            callback?.Invoke(wasShown ? AdResult.SuccessResult("interstitial") : AdResult.ClosedResult("interstitial"));
        }

        private void HandleInterstitialError()
        {
            Action<AdResult> callback = interstitialCallback;
            interstitialCallback = null;
            callback?.Invoke(AdResult.FailedResult("interstitial"));
        }

        private void HandleRewardedSuccess(string placementId)
        {
            if (string.IsNullOrEmpty(placementId))
                placementId = "default";

            Action<AdResult> callback;
            if (!rewardedCallbacks.TryGetValue(placementId, out callback))
                return;

            rewardedCallbacks.Remove(placementId);
            callback?.Invoke(AdResult.SuccessResult(placementId));
        }

        private void HandleRewardedClosed()
        {
            CompleteOpenRewarded(AdResult.ClosedResult());
        }

        private void HandleRewardedError()
        {
            CompleteOpenRewarded(AdResult.FailedResult(null, "Rewarded ad failed."));
        }

        private void CompleteOpenRewarded(AdResult result)
        {
            foreach (KeyValuePair<string, Action<AdResult>> callback in rewardedCallbacks)
            {
                callback.Value?.Invoke(result);
            }

            rewardedCallbacks.Clear();
        }
    }

    public sealed class Pyg2SaveService : ISaveService
    {
        public void SaveInt(string key, int value) => SetEntry(key, value.ToString());
        public int LoadInt(string key, int defaultValue = 0) => int.TryParse(GetEntry(key), out int value) ? value : defaultValue;

        public void SaveFloat(string key, float value) => SetEntry(key, value.ToString(System.Globalization.CultureInfo.InvariantCulture));
        public float LoadFloat(string key, float defaultValue = 0f) => float.TryParse(GetEntry(key), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float value) ? value : defaultValue;

        public void SaveString(string key, string value) => SetEntry(key, value ?? string.Empty);
        public string LoadString(string key, string defaultValue = "") => HasKey(key) ? GetEntry(key) : defaultValue;

        public void SaveBool(string key, bool value) => SetEntry(key, value ? "1" : "0");
        public bool LoadBool(string key, bool defaultValue = false) => HasKey(key) ? GetEntry(key) == "1" : defaultValue;

        public bool HasKey(string key) => FindEntry(key) != null;
        public void DeleteKey(string key) => YG2.saves.nuclearDeclineData.RemoveAll(entry => entry.key == key);

        public void Save()
        {
            if (YG2.isSDKEnabled)
                YG2.SaveProgress();
        }

        public void Load()
        {
            YG2.GetDataInvoke();
        }

        public int GetInt(string key, int defaultValue = 0) => LoadInt(key, defaultValue);
        public void SetInt(string key, int value) => SaveInt(key, value);
        public float GetFloat(string key, float defaultValue = 0f) => LoadFloat(key, defaultValue);
        public void SetFloat(string key, float value) => SaveFloat(key, value);
        public string GetString(string key, string defaultValue = "") => LoadString(key, defaultValue);
        public void SetString(string key, string value) => SaveString(key, value);
        public bool GetBool(string key, bool defaultValue = false) => LoadBool(key, defaultValue);
        public void SetBool(string key, bool value) => SaveBool(key, value);

        private void SetEntry(string key, string value)
        {
            NuclearDeclineSaveEntry entry = FindEntry(key);
            if (entry == null)
            {
                entry = new NuclearDeclineSaveEntry { key = key };
                YG2.saves.nuclearDeclineData.Add(entry);
            }

            entry.value = value;
        }

        private string GetEntry(string key)
        {
            NuclearDeclineSaveEntry entry = FindEntry(key);
            return entry != null ? entry.value : null;
        }

        private NuclearDeclineSaveEntry FindEntry(string key)
        {
            return YG2.saves.nuclearDeclineData.Find(entry => entry.key == key);
        }
    }

    public sealed class Pyg2LocalizationService : ILocalizationService
    {
        private static readonly string[] Languages =
        {
            "ru", "en", "tr", "az", "be", "he", "hy", "ka", "et", "fr", "kk", "ky", "lt", "lv",
            "ro", "tg", "tk", "uk", "uz", "es", "pt", "ar", "id", "ja", "it", "de", "hi"
        };

        public event Action<string> OnLanguageChanged;
        public event Action<string> LanguageChanged;

        public string CurrentLanguage { get; private set; } = "ru";
        public string DefaultLanguage => "ru";
        public string[] SupportedLanguages => (string[])Languages.Clone();

        public void Initialize()
        {
            YG2.onSwitchLang -= HandleLanguageChanged;
            YG2.onSwitchLang += HandleLanguageChanged;
            SyncFromSdk();
        }

        public void SyncFromSdk()
        {
            string sdkLanguage = YG2.lang;

            if (string.IsNullOrEmpty(sdkLanguage) && YG2.envir != null)
                sdkLanguage = YG2.envir.language;

            HandleLanguageChanged(sdkLanguage);
        }

        public void SetLanguage(string languageCode)
        {
            languageCode = Normalize(languageCode);

            if (YG2.lang != languageCode)
                YG2.SwitchLanguage(languageCode);
            else
                HandleLanguageChanged(languageCode);
        }

        public bool IsLanguageSupported(string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return false;

            for (int i = 0; i < Languages.Length; i++)
            {
                if (Languages[i] == languageCode)
                    return true;
            }

            return false;
        }

        public string GetText(string key)
        {
            return key;
        }

        private void HandleLanguageChanged(string languageCode)
        {
            languageCode = Normalize(languageCode);

            if (CurrentLanguage == languageCode)
                return;

            CurrentLanguage = languageCode;
            OnLanguageChanged?.Invoke(CurrentLanguage);
            LanguageChanged?.Invoke(CurrentLanguage);
        }

        private string Normalize(string languageCode)
        {
            languageCode = string.IsNullOrEmpty(languageCode) ? DefaultLanguage : languageCode.ToLowerInvariant();
            return IsLanguageSupported(languageCode) ? languageCode : DefaultLanguage;
        }
    }

    public sealed class Pyg2LeaderboardService : ILeaderboardService
    {
        private const string DefaultLeaderboardName = "leaderboard";

        public void SetScore(string leaderboardName, int score)
        {
            if (string.IsNullOrEmpty(leaderboardName))
                leaderboardName = DefaultLeaderboardName;

            YG2.SetLeaderboard(leaderboardName, score);
        }

        public void RequestLeaderboard(string leaderboardName)
        {
            if (string.IsNullOrEmpty(leaderboardName))
                leaderboardName = DefaultLeaderboardName;

            YG2.GetLeaderboard(leaderboardName);
        }
    }
}
