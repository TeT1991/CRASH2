using System;
using NuclearDecline.Runtime.Ads;
using UnityEngine;

namespace NuclearDecline.Runtime.Mock
{
    public sealed class MockAdsService : IAdsService
    {
        public bool IsInterstitialAvailable => true;
        public bool IsRewardedAvailable => true;

        public void ShowInterstitial(Action<AdResult> onComplete = null)
        {
            Debug.Log("[NuclearDecline] Mock interstitial ad shown.");
            onComplete?.Invoke(AdResult.Completed);
        }

        public void ShowRewarded(string placementId, Action<AdResult> onComplete = null)
        {
            Debug.Log("[NuclearDecline] Mock rewarded ad shown. Placement: " + placementId);
            onComplete?.Invoke(AdResult.Completed);
        }
    }
}
