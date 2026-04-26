using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
public class Save : MonoBehaviour
{
    public GameObject Pause;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown("backspace"))
        {
            Application.LoadLevel("Menu");
            Timmmer.Timer = 0;
            YandexGame.FullscreenShow();
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (Input.GetKeyDown("p"))
        {
            Pause.SetActive(true);
        }
    }

}
