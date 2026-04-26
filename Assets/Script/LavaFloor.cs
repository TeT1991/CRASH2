using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour
{

    public static LavaFloor instance;
    public int LBKillScore;


    private void Awake()
    {
        instance = this;
        LBKillScore = PlayerPrefs.GetInt("LBScore");
    }

    private void Update()
    {



        PlayerPrefs.SetInt("LBScore", LBKillScore);
    }

}
