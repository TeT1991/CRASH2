using System;
using UnityEngine;

namespace NuclearDecline
{
    public static class GamePlatformBridge
    {
        private static IPlatformService service;
        private static ILocalizationService subscribedLocalization;
        private static string lastForwardedLanguage;

        public static event Action<IPlatformService> PlatformChanged;
        public static event Action<string> LanguageChanged;

        public static IPlatformService Platform
        {
            get
            {
                EnsureInitialized();
                return service;
            }
        }

        public static IPlatformService Service => Platform;

        public static IAdsService Ads => Platform.Ads;
        public static ISaveService Saves => Platform.Saves;
        public static ILocalizationService Localization => Platform.Localization;

        public static bool IsInitialized => service != null && service.IsInitialized;

        public static void Initialize(IPlatformService platformService = null)
        {
            IPlatformService previousService = service;

            if (platformService != null && service != platformService)
            {
                if (service != null && service.IsInitialized && !(service is MockPlatformService))
                    return;

                service = platformService;
            }
            else if (service != null && service.IsInitialized)
            {
                return;
            }

            if (service == null)
                service = new MockPlatformService();

            service.Initialize();
            SubscribeLocalization(service.Localization);

            if (previousService != service)
                PlatformChanged?.Invoke(service);

            Debug.Log("[NuclearDecline] GamePlatformBridge initialized: " + service.PlatformName);
        }

        private static void EnsureInitialized()
        {
            if (service == null || !service.IsInitialized)
                Initialize();
        }

        private static void SubscribeLocalization(ILocalizationService localization)
        {
            if (subscribedLocalization == localization)
                return;

            if (subscribedLocalization != null)
            {
                subscribedLocalization.OnLanguageChanged -= HandleLanguageChanged;
                subscribedLocalization.LanguageChanged -= HandleLanguageChanged;
            }

            subscribedLocalization = localization;
            lastForwardedLanguage = null;

            if (subscribedLocalization != null)
            {
                subscribedLocalization.OnLanguageChanged += HandleLanguageChanged;
                subscribedLocalization.LanguageChanged += HandleLanguageChanged;
            }
        }

        private static void HandleLanguageChanged(string languageCode)
        {
            if (lastForwardedLanguage == languageCode)
                return;

            lastForwardedLanguage = languageCode;
            LanguageChanged?.Invoke(languageCode);
        }
    }
}
