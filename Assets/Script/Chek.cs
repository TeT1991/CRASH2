using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chek : MonoBehaviour
{
    public GameObject W1;
    public GameObject W2;
    public GameObject W3;
    public GameObject W4;

    // Update is called once per frame

    void Start()
    {
        if (PlayerPrefs.GetInt("Chek1") == 1)
        {
            W1.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Chek2") == 1)
        {
            W2.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Chek3") == 1)
        {
            W3.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Chek4") == 1)
        {
            W4.SetActive(true);
        }
    }
}
