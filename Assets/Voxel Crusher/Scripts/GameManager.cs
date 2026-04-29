using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float noIncomeEndDelay = 15f;

    private int lastCoins;
    private float noIncomeTimer;
    private bool levelEndScheduled;

    private void Awake()
    {
        RobotFuel.OnFuelEmpty += FuelEmptyCallback;
        UIManager.onGameSet += ResetNoIncomeTimer;
    }

    private void OnDestroy()
    {
        RobotFuel.OnFuelEmpty -= FuelEmptyCallback;
        UIManager.onGameSet -= ResetNoIncomeTimer;
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIManager.IsGame() || levelEndScheduled)
            return;

        if (UIManager.COINS > lastCoins)
        {
            lastCoins = UIManager.COINS;
            noIncomeTimer = 0;
            return;
        }

        noIncomeTimer += Time.deltaTime;

        if (noIncomeTimer >= noIncomeEndDelay)
            FuelEmptyCallback();
    }

    public void FuelEmptyCallback()
    {
        if (levelEndScheduled)
            return;

        levelEndScheduled = true;
        LeanTween.delayedCall(1, () => UIManager.setLevelCompleteDelegate?.Invoke());


        Debug.Log("Setting level complete...");
    }

    private void ResetNoIncomeTimer()
    {
        lastCoins = UIManager.COINS;
        noIncomeTimer = 0;
        levelEndScheduled = false;
    }
}
