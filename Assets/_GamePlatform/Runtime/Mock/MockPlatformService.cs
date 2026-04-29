using GamePlatform.Runtime.Ads;
using GamePlatform.Runtime.Core;
using GamePlatform.Runtime.Localization;
using GamePlatform.Runtime.Saves;
using UnityEngine;

namespace GamePlatform.Runtime.Mock
{
    public sealed class MockPlatformService : IPlatformService
    {
        public bool IsInitialized { get; private set; }
        public string PlatformName => "Mock";

        public IAdsService Ads { get; private set; }
        public ILocalizationService Localization { get; private set; }
        public ISaveService Saves { get; private set; }

        public void Initialize()
        {
            if (IsInitialized)
                return;

            Saves = new MockSaveService();
            Localization = new MockLocalizationService(Saves);
            Ads = new MockAdsService();

            IsInitialized = true;
            Debug.Log("[GamePlatform] Mock platform service ready.");
        }
    }
}
