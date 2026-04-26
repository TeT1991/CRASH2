using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollFix : MonoBehaviour
{
    public GameObject Rag;

    private void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    private void Update()
    {
        Rag = GameObject.Find("RagdollContainer HUGILevel 1(Clone)");

    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(Rag);
        StartCoroutine(ExampleCoroutine());
    }

}
