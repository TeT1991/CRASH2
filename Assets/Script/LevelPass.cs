using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class LevelPass : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            Wood.instance.WoodCount += 100;
            Application.LoadLevel("Loader");
        }

    }
}
