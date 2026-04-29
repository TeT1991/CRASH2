using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeManager : MonoBehaviour
{
    public GameObject Self;
    public int WoodCost;
    public int WoodCostText;
    public int LevelText;
    public TextMeshProUGUI WoodText;
     public TextMeshProUGUI LevelingText;
    public Button BuildButton;


    public void UpgradedLevel()
    {
        Wood.instance.WoodCount -= WoodCostText;
        LevelText += 1;
        Self.SetActive(false);
        ShowInterstitial();
    }

    private void ShowInterstitial()
    {
        if (!NuclearDecline.GamePlatformBridge.IsInitialized)
            NuclearDecline.GamePlatformBridge.Initialize();

        NuclearDecline.GamePlatformBridge.Ads?.ShowInterstitial();
    }

    // Update is called once per frame
    void Update()
    {
        WoodText.text = "" + WoodCostText;

        LevelingText.text = "" + LevelText;


        if (Wood.instance.WoodCount >= WoodCost)
        {
            BuildButton.interactable = true;
        }

        if (Wood.instance.WoodCount <= WoodCost)
        {
            BuildButton.interactable = false;
        }
    }
}
