using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToPont : MonoBehaviour
{

    public GameObject Player;
    public GameObject PuppetPlayer;
    //public GameObject WaveStart;
    public Transform Point;
    public Transform Home;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PuppetPlayer.SetActive(false);
            Player.SetActive(false);
            StartCoroutine(ExampleCoroutine());
        }

    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        Player.transform.position = Point.position;
        yield return new WaitForSeconds(0.1f);
        Player.SetActive(true);
        PuppetPlayer.SetActive(true);
        // WaveStart.SetActive(true);
    }

}
