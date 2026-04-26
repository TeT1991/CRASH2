using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDiamond : MonoBehaviour
{
    public static AddDiamond instance;




    public int LKill;

    private void Awake()
    {
        instance = this;

    }


    void Start()
    {
        LavaFloor.instance.LBKillScore += 1;
        Debug.Log("В табло!");
    }

}
