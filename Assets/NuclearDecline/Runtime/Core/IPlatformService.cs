using NuclearDecline.Runtime.Ads;
using NuclearDecline.Runtime.Localization;
using NuclearDecline.Runtime.Saves;

namespace NuclearDecline.Runtime.Core
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
