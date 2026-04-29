using NuclearDecline;
using UnityEngine;

namespace YG
{
    internal static class NuclearDeclineYandexLanguageAdapter
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            YandexGame.SwitchLangEvent -= HandleLanguageChanged;
            YandexGame.SwitchLangEvent += HandleLanguageChanged;
        }

        private static void HandleLanguageChanged(string languageCode)
        {
            GamePlatformBridge.Localization.SetLanguage(languageCode);
        }
    }
}
