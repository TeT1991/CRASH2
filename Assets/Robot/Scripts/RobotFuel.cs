using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using JetSystems;

public class RobotFuel : MonoBehaviour
{
    public static RobotFuel instance;

    [Header(" Elements ")]
    [SerializeField] private Slider fuelSlider;

    [Header(" Settings ")]
    [SerializeField] private float[] diminishRates;
    [SerializeField] private int[] upgradeFuelPrices;

    [Header(" Fuel Upgrade ")]
    [SerializeField] private Button upgradeFuelButton;
    [SerializeField] private Text upgradeFuelPriceText;

    private float fuel;
    private int fuelLevel;

    [Header(" Events ")]
    public static Action OnFuelEmpty;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        LoadData();

        UIManager.onGameSet += Refuel;
        UIManager.onMenuSet += UpdateUI;
    }

    // Start is called before the first frame update
    void Start()
    {
        RobotController.OnRobotBeingUsed += UseRobot;
        LevelManager.OnNextLevelSet += ResetFuelLevel;

        UIManager.instance.OnCoinsUpdated += UpdateUI;
    }

    private void OnDestroy()
    {
        RobotController.OnRobotBeingUsed -= UseRobot;
        UIManager.onGameSet -= Refuel;
        UIManager.onMenuSet -= UpdateUI;

        UIManager.instance.OnCoinsUpdated -= UpdateUI;

        LevelManager.OnNextLevelSet -= ResetFuelLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PurchaseFuelUpgrade()
    {
        UIManager.AddCoins(-upgradeFuelPrices[fuelLevel]);

        fuelLevel++;
        SaveData();

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (fuelLevel >= upgradeFuelPrices.Length)
        {
            upgradeFuelPriceText.text = "MAX";
            upgradeFuelButton.interactable = false;
            return;
        }

        upgradeFuelPriceText.text = upgradeFuelPrices[fuelLevel].ToString();
        upgradeFuelButton.interactable = UIManager.COINS >= upgradeFuelPrices[fuelLevel]; //PlayerTrader.instance.HasEnoughDiamonds( upgradePrices[armLevel] );
    }

    private void UseRobot()
    {
        float targetFuel = Mathf.Clamp01(fuel - diminishRates[fuelLevel] * Time.deltaTime);
        fuel = targetFuel;

        fuelSlider.value = fuel;

        if(fuel <= 0)
            OnFuelEmpty?.Invoke();
    }

    public bool HasFuel()
    {
        return fuel > 0;
    }

    private void Refuel()
    {
        fuel = 1;
        fuelSlider.value = fuel;
    }

    private void ResetFuelLevel()
    {
        fuelLevel = 0;
        SaveData();
    }

    private void LoadData()
    {
        fuelLevel = PlayerPrefs.GetInt("FuelLevel");
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("FuelLevel", fuelLevel);
    }
}
