using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetSystems;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        RobotFuel.OnFuelEmpty += FuelEmptyCallback;
    }

    private void OnDestroy()
    {
        RobotFuel.OnFuelEmpty -= FuelEmptyCallback;
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FuelEmptyCallback()
    {
        LeanTween.delayedCall(1, () => UIManager.setLevelCompleteDelegate?.Invoke());


        Debug.Log("Setting level complete...");
    }
}
