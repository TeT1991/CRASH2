using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LAVA : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            YandexGame.FullscreenShow();
            Cursor.lockState = CursorLockMode.Confined;
            Application.LoadLevel("Menu");
        }

    }
}
