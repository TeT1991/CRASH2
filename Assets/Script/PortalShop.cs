using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalShop : MonoBehaviour
{
    public Button CharButton1;
    public Button CharButton2;
    public Button CharButton3;


    public void Portal1()
    {
        DiamondChkeer.instance.Diamond -= 300;
        PlayerPrefs.SetInt("Lock31", 1);
        PlayerPrefs.SetInt("Random", 1);
        Destroy(CharButton1.gameObject);
    }

    public void Portal2()
    {
        DiamondChkeer.instance.Diamond -= 500;
        PlayerPrefs.SetInt("Lock32", 1);
        PlayerPrefs.SetInt("Random", 2);
        Destroy(CharButton2.gameObject);
    }

    public void Portal3()
    {
        DiamondChkeer.instance.Diamond -= 1000;
        PlayerPrefs.SetInt("Lock33", 1);
        PlayerPrefs.SetInt("Random", 3);
        Destroy(CharButton3.gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        if (DiamondChkeer.instance.Diamond >= 299)
        {
            CharButton1.interactable = true;
        }

        if (DiamondChkeer.instance.Diamond <= 299)
        {
            CharButton1.interactable = false;
        }

        if (DiamondChkeer.instance.Diamond >= 499)
        {
            CharButton2.interactable = true;
        }

        if (DiamondChkeer.instance.Diamond <= 499)
        {
            CharButton2.interactable = false;
        }

        if (DiamondChkeer.instance.Diamond >= 999)
        {
            CharButton3.interactable = true;
        }

        if (DiamondChkeer.instance.Diamond <= 999)
        {
            CharButton3.interactable = false;
        }

        if (PlayerPrefs.GetInt("Lock31") == 1)
        {
            Destroy(CharButton1.gameObject);
        }

        if (PlayerPrefs.GetInt("Lock32") == 1)
        {
            Destroy(CharButton2.gameObject);
        }

        if (PlayerPrefs.GetInt("Lock33") == 1)
        {
            Destroy(CharButton3.gameObject);
        }
    }
}
