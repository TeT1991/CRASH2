using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeapNComManager : MonoBehaviour
{

  //  public GameObject Weap1;
  //  public GameObject Weap2;
  //  public GameObject Weap3;
    public GameObject Com1;
    public GameObject Com2;
    public GameObject Com3;


    void Update()
    {
        if (PlayerPrefs.GetInt("Weapon") == 1)
        {
      //      Weap1.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Weapon") == 2)
        {
            
     //       Weap2.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Weapon") == 3)
        {
    //        Weap3.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Companion") == 1)
        {
            Com1.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Companion") == 2)
        {

            Com1.SetActive(true);
            Com2.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Companion") == 3)
        {
            Com1.SetActive(true);
            Com2.SetActive(true);
            Com3.SetActive(true);
        }
    }
}
