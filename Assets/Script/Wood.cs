using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Wood : MonoBehaviour
{
    public static Wood instance;
    public TextMeshProUGUI WoodText;

    public int WoodCount;


    private void Awake()
    {
        instance = this;
    }

    public void WoodPlus()
    {
        WoodCount += 200;
    }


    void Start()
    {
        WoodCount = PlayerPrefs.GetInt("Wood");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Wood", WoodCount);
        WoodText.text = "" + WoodCount;
    }
}
