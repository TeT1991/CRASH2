using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWorking : MonoBehaviour
{
    public GameObject Worker1;
    public GameObject Worker2;
    public GameObject Worker3;

    public void WoodCutter()
    {

    }


    public void SetWorker1()
    {
            PlayerPrefs.SetInt("Worker1", 1);
    }

    
    public void SetWorker2()
    {
            PlayerPrefs.SetInt("Worker1", 2);
    }

        public void SetWorker3()
    {
            PlayerPrefs.SetInt("Worker1", 3);
    }

    public void SetCom1()
    {
        PlayerPrefs.SetInt("Companion", 1);
    }

    public void SetCom2()
    {
        PlayerPrefs.SetInt("Companion", 2);
    }

    public void SetCom3()
    {
        PlayerPrefs.SetInt("Companion", 3);
    }


    void Update()
    {
         if (PlayerPrefs.GetInt("Worker1") == 1)
        {
            Worker1.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Worker1") == 2)
        {
            Worker1.SetActive(true);
            Worker2.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Worker1") == 3)
        {
            Worker1.SetActive(true);
            Worker2.SetActive(true);
            Worker3.SetActive(true);
        }
    }
}
