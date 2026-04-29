using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JetSystems;
using NuclearDecline;

public class RobotUpgrade : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Robot robot;
    [SerializeField] private Button upgradeArmButton;
    [SerializeField] private Text upgradeArmPriceText;

    [Header(" Settings ")]
    [SerializeField] private int[] upgradePrices;

    [Header(" Saving ")]
    private int armLevel;

    private void Awake() 
    {
        LoadData();    
    }

    private void OnDestroy()
    {
        LevelManager.OnNextLevelSet -= ResetArmLevel;
        UIManager.instance.OnCoinsUpdated -= ManageUpgradeButtonInteractability;
    }

    private void LoadData()
    {
        armLevel = PlayerPrefs.GetInt("Robot_ArmLevel");         
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("Robot_ArmLevel", armLevel);
    }

    private void ResetArmLevel()
    {
        armLevel = 0;
        SaveData();
    }

        // Start is called before the first frame update
    IEnumerator Start()
    {
        LevelManager.OnNextLevelSet += ResetArmLevel;
        UIManager.instance.OnCoinsUpdated += ManageUpgradeButtonInteractability;

        yield return robot.IsInitialized();

        for (int i = 0; i < armLevel; i++)
            robot.AddArm();            
    }

    public void PurchaseRobotArmUpgrade()
    {
        //PlayerTrader.instance.PurchaseWithDiamonds(upgradePrices[armLevel]);

        UIManager.AddCoins(-upgradePrices[armLevel]);

        armLevel++;
        SaveData();

        robot.AddArm();

        GamePlatformBridge.Ads.ShowInterstitial();
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldUpdate())
            ManageUpgradeButtonInteractability();
    }

    private void ManageUpgradeButtonInteractability()
    {
        if(armLevel >= upgradePrices.Length)
        {
            upgradeArmPriceText.text = "MAX";
            upgradeArmButton.interactable = false;
            return;
        }

        upgradeArmPriceText.text = upgradePrices[armLevel].ToString();
        upgradeArmButton.interactable = UIManager.COINS >= upgradePrices[armLevel]; //PlayerTrader.instance.HasEnoughDiamonds( upgradePrices[armLevel] );
    }

    private bool ShouldUpdate()
    {
        return robot.GetComponent<JetSystems.SlideInput>().enabled;
    }
}
