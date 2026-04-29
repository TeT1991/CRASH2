using System;

namespace GamePlatform.Runtime.Localization
{
    public interface ILocalizationService
    {
        string CurrentLanguage { get; }

        event Action<string> LanguageChanged;

        void SetLanguage(string languageCode);
    }
}
