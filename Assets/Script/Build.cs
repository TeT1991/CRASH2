using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;
public class Build : MonoBehaviour
{
    public GameObject Self;
    public int WoodCost;
    public int WoodCostText;
    public TextMeshProUGUI WoodText;
    public Button BuildButton;


    public void NewBuild()
    {
        Wood.instance.WoodCount -= WoodCostText;
        Self.SetActive(false);
        YandexGame.FullscreenShow();
    }

    void Update()
    {
        WoodText.text = "" + WoodCostText;


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
