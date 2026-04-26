using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DiamondChkeer : MonoBehaviour
{
    public static DiamondChkeer instance;
    public TextMeshProUGUI CoinText;

    public int Diamond = 0;


    private void Awake()
    {
        instance = this;
    }

    public void DiamonPlus()
    {
        Diamond += 250;
    }

    public void DiamonDonate()
    {
        Diamond += 1000;
    }


    void Start()
    {
        Diamond = PlayerPrefs.GetInt("Coin");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Coin", Diamond);
        CoinText.text = "" + Diamond;
    }
}
