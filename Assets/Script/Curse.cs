using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curse : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        AudioListener.volume = 0f;
    }

}
