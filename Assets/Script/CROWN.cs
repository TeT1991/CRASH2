using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CROWN : MonoBehaviour
{
    public GameObject UI;
    public GameObject Player;
    void Start()
    {
        
    }


    public void ResetaTimer()
    {
        Timmmer.Timer = 0;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.SetActive(true);
            Player.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0.0f;
        }

    }
}
