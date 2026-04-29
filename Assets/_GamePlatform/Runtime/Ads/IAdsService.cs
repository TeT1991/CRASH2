using System;

namespace GamePlatform.Runtime.Ads
{
    public interface IAdsService
    {
        bool IsFullscreenAdAvailable { get; }
        bool IsRewardedAdAvailable { get; }

        void ShowFullscreenAd(Action<AdResult> onComplete = null);
        void ShowRewardedAd(string placementId, Action<AdResult> onComplete = null);
    }
}
