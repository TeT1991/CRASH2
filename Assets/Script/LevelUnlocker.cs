using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public Button CharButton1;
    public Button CharButton2;
    public Button CharButton3;
    public Button CharButton4;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void BuyItem1()
    {
        DiamondChkeer.instance.Diamond -= 50;
        PlayerPrefs.SetInt("Lock1", 1);
        PlayerPrefs.SetInt("Chek1", 1);
        Destroy(CharButton1.gameObject);

    }

    public void BuyItem2()
    {
        DiamondChkeer.instance.Diamond -= 150;
        PlayerPrefs.SetInt("Lock2", 1);
        PlayerPrefs.SetInt("Chek2", 1);
        Destroy(CharButton2.gameObject);

    }

    public void BuyItem3()
    {
        DiamondChkeer.instance.Diamond -= 250;
        PlayerPrefs.SetInt("Lock3", 1);
        PlayerPrefs.SetInt("Chek3", 1);
        Destroy(CharButton3.gameObject);

    }

    public void BuyItem4()
    {
        DiamondChkeer.instance.Diamond -= 400;
        PlayerPrefs.SetInt("Lock4", 1);
        PlayerPrefs.SetInt("Chek4", 1);
        Destroy(CharButton4.gameObject);

    }


    // Update is called once per frame
    void Update()
    {
        if (DiamondChkeer.instance.Diamond >= 49)
        {
            CharButton1.interactable = true;
        }

        if (DiamondChkeer.instance.Diamond <= 49)
        {
            CharButton1.interactable = false;
        }

        if (DiamondChkeer.instance.Diamond >= 149)
        {
            CharButton2.interactable = true;
        }

        if (DiamondChkeer.instance.Diamond <= 149)
        {
            CharButton2.interactable = false;
        }

        if (DiamondChkeer.instance.Diamond >= 249)
        {
            CharButton3.interactable = true;
        }

        if (DiamondChkeer.instance.Diamond <= 249)
        {
            CharButton3.interactable = false;
        }

        if (DiamondChkeer.instance.Diamond >= 399)
        {
            CharButton4.interactable = true;
        }

        if (DiamondChkeer.instance.Diamond <= 399)
        {
            CharButton4.interactable = false;
        }

        if (PlayerPrefs.GetInt("Lock1") == 1)
        {
            Destroy(CharButton1.gameObject);
        }

        if (PlayerPrefs.GetInt("Lock2") == 1)
        {
            Destroy(CharButton2.gameObject);
        }

        if (PlayerPrefs.GetInt("Lock3") == 1)
        {
            Destroy(CharButton3.gameObject);
        }

        if (PlayerPrefs.GetInt("Lock4") == 1)
        {
            Destroy(CharButton4.gameObject);
        }

    }
}
