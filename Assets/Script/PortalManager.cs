using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject Portal1;
    public GameObject Portal2;
    public GameObject Portal3;
    void Update()
    {

        if (PlayerPrefs.GetInt("Speed") == 1)
        {
            Portal1.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Speed") == 2)
        {;
            Portal2.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Speed") == 3)
        {
            Portal3.SetActive(true);
        }
    }
}
