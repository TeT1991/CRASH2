using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiShop : MonoBehaviour
{
    public Button CharButton1;
    public Button CharButton2;
    public Button CharButton3;


    public void Mult1()
    {
        DiamondChkeer.instance.Diamond -= 300;
        PlayerPrefs.SetInt("Lock21", 1);
        PlayerPrefs.SetInt("Speed", 1);
        Destroy(CharButton1.gameObject);
    }

    public void Mult2()
    {
        DiamondChkeer.instance.Diamond -= 500;
        PlayerPrefs.SetInt("Lock22", 1);
        PlayerPrefs.SetInt("Speed", 2);
        Destroy(CharButton2.gameObject);
    }

    public void Mult3()
    {
        DiamondChkeer.instance.Diamond -= 1000;
        PlayerPrefs.SetInt("Lock23", 1);
        PlayerPrefs.SetInt("Speed", 3);
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

        if (PlayerPrefs.GetInt("Lock21") == 1)
        {
            Destroy(CharButton1.gameObject);
        }

        if (PlayerPrefs.GetInt("Lock22") == 1)
        {
            Destroy(CharButton2.gameObject);
        }

        if (PlayerPrefs.GetInt("Lock23") == 1)
        {
            Destroy(CharButton3.gameObject);
        }
    }
}
