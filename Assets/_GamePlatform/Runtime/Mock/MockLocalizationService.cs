using System;
using GamePlatform.Runtime.Localization;
using GamePlatform.Runtime.Saves;
using UnityEngine;

namespace GamePlatform.Runtime.Mock
{
    public sealed class MockLocalizationService : ILocalizationService
    {
        private const string LanguageKey = "GamePlatform.Language";
        private readonly ISaveService saveService;

        public event Action<string> LanguageChanged;

        public string CurrentLanguage { get; private set; }

        public MockLocalizationService(ISaveService saveService)
        {
            this.saveService = saveService;
            CurrentLanguage = saveService.GetString(LanguageKey, "ru");
        }

        public void SetLanguage(string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                languageCode = "ru";

            if (CurrentLanguage == languageCode)
                return;

            CurrentLanguage = languageCode;
            saveService.SetString(LanguageKey, CurrentLanguage);
            saveService.Save();

            Debug.Log("[GamePlatform] Mock language changed: " + CurrentLanguage);
            LanguageChanged?.Invoke(CurrentLanguage);
        }
    }
}
