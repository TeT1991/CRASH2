using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopValue : MonoBehaviour
{
    public int WoodCost;
    public TextMeshProUGUI WoodText;
    public Button BuildButton;


    public void ValueChange()
    {
        Wood.instance.WoodCount -= 50;
        DiamondChkeer.instance.Diamond += 25;
        ShowInterstitial();
    }

    private void ShowInterstitial()
    {
        if (!NuclearDecline.GamePlatformBridge.IsInitialized)
            NuclearDecline.GamePlatformBridge.Initialize();

        NuclearDecline.GamePlatformBridge.Ads?.ShowInterstitial();
    }

    void Update()
    {

        if (Wood.instance.WoodCount >= 49)
        {
            BuildButton.interactable = true;
        }

        if (Wood.instance.WoodCount <= 49)
        {
            BuildButton.interactable = false;
        }
    }
}
