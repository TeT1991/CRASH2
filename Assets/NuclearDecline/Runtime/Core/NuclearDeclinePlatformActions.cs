using UnityEngine;

namespace NuclearDecline
{
    public sealed class NuclearDeclinePlatformActions : MonoBehaviour
    {
        public void ShowInterstitial()
        {
            GamePlatformBridge.Ads.ShowInterstitial();
        }

        public void ShowRewarded(int placementId)
        {
            GamePlatformBridge.Ads.ShowRewarded(placementId.ToString());
        }

        public void RequestAuthorization()
        {
            Debug.Log("[NuclearDecline] Authorization request is not exposed by the bridge yet.");
        }
    }
}
