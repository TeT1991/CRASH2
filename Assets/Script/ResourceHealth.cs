using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHealth : MonoBehaviour
{
    public int ResourceH;
    public Animator ResororceAnimator;
    public GameObject TextFx;
    public GameObject TextFx2;
    public GameObject Respawn;



    public void SetHit()
    {
        ResourceH -= 1;
        Wood.instance.WoodCount += 1;
        TextFx.GetComponent<Animator>().Play("FX");
    }

    public void SetHitDaimond()
    {
        ResourceH -= 1;
        DiamondChkeer.instance.Diamond += 1;
        TextFx2.GetComponent<Animator>().Play("FX2");
    }


    void Start()
    {
        ResourceH = Random.Range(5, 30);
        TextFx = GameObject.Find("GOLD");
        TextFx2 = GameObject.Find("DIAMOND");
    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceH <= 0)
        {
            Wood.instance.WoodCount += 4;
            ResororceAnimator.Play("TreeDestroy");
            ResourceH = Random.Range(5, 30);
            Respawn.SetActive(true);
        }
    }
}