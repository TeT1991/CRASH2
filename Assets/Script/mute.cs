using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mute : MonoBehaviour
{

    public GameObject mutepng;
    public GameObject mutepng1;
    //public GameObject Music;
    public void MuteToggl()
    {
        PlayerPrefs.SetInt("mute",  0);
      //  Music.SetActive(true);
        mutepng.SetActive(true);
            mutepng1.SetActive(false);
        AudioListener.volume = 1f;
    }

    public void MuteToggl1()
    {
        PlayerPrefs.SetInt("mute", 1);
     //   Music.SetActive(false);
        mutepng.SetActive(false);
        mutepng1.SetActive(true);
        AudioListener.volume = 0f;
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("mute") == 0)
        {
          //  Music.SetActive(true);
            mutepng.SetActive(true);
            mutepng1.SetActive(false);
            AudioListener.volume = 1f;
        }

        if (PlayerPrefs.GetInt("mute") == 1)
        {
            AudioListener.volume = 0f;
            //  Music.SetActive(false);
            mutepng.SetActive(false);
            mutepng1.SetActive(true);
        }
    }
}
