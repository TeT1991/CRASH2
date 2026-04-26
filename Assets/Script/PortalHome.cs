using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class PortalHome : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            YandexGame.FullscreenShow();
            Application.LoadLevel("Loader");
        }

    }
}
