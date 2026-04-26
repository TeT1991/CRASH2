using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{

public ParticleSystem Fx;

public int GoldCount;


public void OpenedChest()
{
    {
    Fx.Play();
    DiamondChkeer.instance.Diamond += GoldCount;
    StartCoroutine(ExampleCoroutine());

    }
}

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }




}
