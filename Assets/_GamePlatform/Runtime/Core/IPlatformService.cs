using GamePlatform.Runtime.Ads;
using GamePlatform.Runtime.Localization;
using GamePlatform.Runtime.Saves;

namespace GamePlatform.Runtime.Core
{
    public interface IPlatformService
    {
        bool IsInitialized { get; }
        string PlatformName { get; }

        IAdsService Ads { get; }
        ILocalizationService Localization { get; }
        ISaveService Saves { get; }

        void Initialize();
    }
}
