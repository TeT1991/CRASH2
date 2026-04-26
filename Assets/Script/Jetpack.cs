using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public GameObject Buf1;
    public GameObject Buf2;
    public GameObject Buf3;



    private void Update()
    {
        if (PlayerPrefs.GetInt("Random") == 1)
        {
            Buf1.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Random") == 2)
        {
            Buf2.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Random") == 3)
        {
            Buf3.SetActive(true);
        }
    }



}
