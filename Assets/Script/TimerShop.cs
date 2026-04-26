using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerShop : MonoBehaviour
{
    public Button CharButton1;
    public Button CharButton2;
    public Button CharButton3;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }


    public void Timer1()
    {
        DiamondChkeer.instance.Diamond -= 100;
        PlayerPrefs.SetInt("Lock11", 1);
        PlayerPrefs.SetInt("Health", 1);
        Destroy(CharButton1.gameObject);
    }

    public void Timer2()
    {
        DiamondChkeer.instance.Diamond -= 300;
        PlayerPrefs.SetInt("Lock12", 1);
        PlayerPrefs.SetInt("Health", 2);
        Destroy(CharButton2.gameObject);
    }

    public void Timer3()
    {
        DiamondChkeer.instance.Diamond -= 500;
        PlayerPrefs.SetInt("Lock13", 1);
        PlayerPrefs.SetInt("Health", 3);
        Destroy(CharButton3.gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        if (DiamondChkeer.instance.Diamond >= 99)
        {
            CharButton1.interactable = true;
        }

        if (DiamondChkeer.instance.Diamond <= 99)
        {
            CharButton1.interactable = false;
        }

        if (DiamondChkeer.instance.Diamond >= 299)
        {
            CharButton2.interactable = true;
        }

        if (DiamondChkeer.instance.Diamond <= 299)
        {
            CharButton2.interactable = false;
        }

        if (DiamondChkeer.instance.Diamond >= 499)
        {
            CharButton3.interactable = true;
        }

        if (DiamondChkeer.instance.Diamond <= 499)
        {
            CharButton3.interactable = false;
        }

        if (PlayerPrefs.GetInt("Lock11") == 1)
        {
            Destroy(CharButton1.gameObject);
        }

        if (PlayerPrefs.GetInt("Lock12") == 1)
        {
            Destroy(CharButton2.gameObject);
        }

        if (PlayerPrefs.GetInt("Lock13") == 1)
        {
            Destroy(CharButton3.gameObject);
        }
    }
}
