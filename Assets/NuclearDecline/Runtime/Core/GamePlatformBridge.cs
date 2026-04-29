using NuclearDecline.Runtime.Ads;
using NuclearDecline.Runtime.Core;
using NuclearDecline.Runtime.Localization;
using NuclearDecline.Runtime.Mock;
using NuclearDecline.Runtime.Saves;
using UnityEngine;

namespace NuclearDecline
{
    public static class GamePlatformBridge
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

            Debug.Log("[NuclearDecline] GamePlatformBridge initialized: " + service.PlatformName);
        }

        private static void EnsureInitialized()
        {
            if (service == null || !service.IsInitialized)
                Initialize();
        }
    }
}
