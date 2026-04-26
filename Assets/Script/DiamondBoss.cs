using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBoss : MonoBehaviour
{
    public AudioSource Sound;
    public GameObject Mesh;

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {

            GetComponent<Collider>().enabled = false;
            DiamondChkeer.instance.Diamond += 50;
            Sound.Play();
            Mesh.SetActive(false);
            StartCoroutine(ExampleCoroutine());



            /*            if (PlayerPrefs.GetInt("Chek") == 0)
                        {
                            GetComponent<Collider>().enabled = false;
                            DiamondChkeer.instance.Diamond += 1;
                            Sound.Play();
                            Mesh.SetActive(false);
                            StartCoroutine(ExampleCoroutine());
                        }

                        if (PlayerPrefs.GetInt("Chek") == 1)
                        {
                            GetComponent<Collider>().enabled = false;
                            DiamondChkeer.instance.Diamond += 2;
                            Sound.Play();
                            Mesh.SetActive(false);
                            StartCoroutine(ExampleCoroutine());
                        }

                        if (PlayerPrefs.GetInt("Chek") == 2)
                        {
                            GetComponent<Collider>().enabled = false;
                            DiamondChkeer.instance.Diamond += 3;
                            Sound.Play();
                            Mesh.SetActive(false);
                            StartCoroutine(ExampleCoroutine());
                        }

                        if (PlayerPrefs.GetInt("Chek") == 3)
                        {
                            GetComponent<Collider>().enabled = false;
                            DiamondChkeer.instance.Diamond += 4;
                            Sound.Play();
                            Mesh.SetActive(false);
                            StartCoroutine(ExampleCoroutine());
                        }

                        if (PlayerPrefs.GetInt("Chek") == 4)
                        {
                            GetComponent<Collider>().enabled = false;
                            DiamondChkeer.instance.Diamond += 5;
                            Sound.Play();
                            Mesh.SetActive(false);
                            StartCoroutine(ExampleCoroutine());
                        }*/


        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
