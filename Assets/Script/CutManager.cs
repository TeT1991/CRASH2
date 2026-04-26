using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutManager : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(ExampleCoroutine());

        if (PlayerPrefs.GetInt("CutFirst") == 2)
        {
            Application.LoadLevel("Home");
        }
    }



    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt("CutFirst", 2);
    }


}
