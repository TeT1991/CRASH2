using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekSet : MonoBehaviour
{

    public void SetChek1()
    {
        PlayerPrefs.SetInt("Chek", 0);
    }

    public void SetChek2()
    {
        PlayerPrefs.SetInt("Chek1", 1);
    }

    public void SetChek3()
    {
        PlayerPrefs.SetInt("Chek2", 1);
    }

    public void SetChek4()
    {
        PlayerPrefs.SetInt("Chek3", 1);
    }

    public void SetChek5()
    {
        PlayerPrefs.SetInt("Chek4", 1);
    }


    public void URL()
    {
        Application.OpenURL("https://yandex.ru/games/developer?name=Lory%20Games");
    }


}
