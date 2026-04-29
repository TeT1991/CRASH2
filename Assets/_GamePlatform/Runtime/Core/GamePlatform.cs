using GamePlatform.Runtime.Ads;
using GamePlatform.Runtime.Localization;
using GamePlatform.Runtime.Mock;
using GamePlatform.Runtime.Saves;
using UnityEngine;

namespace GamePlatform.Runtime.Core
{
    public static class GamePlatform
    {
        private static IPlatformService service;

        public static IPlatformService Service
        {
            get
            {
                EnsureInitialized();
                return service;
            }
        }

        public static IAdsService Ads => Service.Ads;
        public static ILocalizationService Localization => Service.Localization;
        public static ISaveService Saves => Service.Saves;

        public static bool IsInitialized => service != null && service.IsInitialized;

        public static void Initialize(IPlatformService platformService = null)
        {
            if (service != null && service.IsInitialized)
                return;

            service = platformService ?? new MockPlatformService();
            service.Initialize();

            Debug.Log("[GamePlatform] Initialized: " + service.PlatformName);
        }

        private static void EnsureInitialized()
        {
            if (service == null || !service.IsInitialized)
                Initialize();
        }
    }
}
