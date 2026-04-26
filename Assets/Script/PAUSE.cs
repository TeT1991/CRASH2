using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAUSE : MonoBehaviour
{
    void Update()
    {
        Time.timeScale = 0.0f;
    }

    public void restepause()
    {
        Time.timeScale = 1.0f;
    }
}
