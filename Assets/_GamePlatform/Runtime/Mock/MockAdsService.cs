using System;
using GamePlatform.Runtime.Ads;
using UnityEngine;

namespace GamePlatform.Runtime.Mock
{
    public sealed class MockAdsService : IAdsService
    {
        public bool IsFullscreenAdAvailable => true;
        public bool IsRewardedAdAvailable => true;

        public void ShowFullscreenAd(Action<AdResult> onComplete = null)
        {
            Debug.Log("[GamePlatform] Mock fullscreen ad shown.");
            onComplete?.Invoke(AdResult.Completed);
        }

        public void ShowRewardedAd(string placementId, Action<AdResult> onComplete = null)
        {
            Debug.Log("[GamePlatform] Mock rewarded ad shown. Placement: " + placementId);
            onComplete?.Invoke(AdResult.Completed);
        }
    }
}
