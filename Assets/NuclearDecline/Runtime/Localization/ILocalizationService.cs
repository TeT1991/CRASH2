using System;

namespace NuclearDecline.Runtime.Localization
{
    public interface ILocalizationService
    {
        string CurrentLanguage { get; }

        event Action<string> LanguageChanged;

        void SetLanguage(string languageCode);
    }
}
