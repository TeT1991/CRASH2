using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHome : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShowInterstitial();
            Application.LoadLevel("Loader");
        }

    }

    private void ShowInterstitial()
    {
        if (!NuclearDecline.GamePlatformBridge.IsInitialized)
            NuclearDecline.GamePlatformBridge.Initialize();

        NuclearDecline.GamePlatformBridge.Ads?.ShowInterstitial();
    }
}
