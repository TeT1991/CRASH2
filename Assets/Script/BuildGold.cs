using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildGold : MonoBehaviour
{
    public GameObject Self;
    public int DiamondCost;
    public int WoodCostText;
    public TextMeshProUGUI WoodText;
    public Button BuildButton;


    public void NewBuild()
    {
        DiamondChkeer.instance.Diamond -= WoodCostText;
        Self.SetActive(false);
    }

    void Update()
    {
        WoodText.text = "" + WoodCostText;


        if (DiamondChkeer.instance.Diamond >= DiamondCost)
        {
            BuildButton.interactable = true;
        }

        if (DiamondChkeer.instance.Diamond <= DiamondCost)
        {
            BuildButton.interactable = false;
        }
    }
}
