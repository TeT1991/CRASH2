using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOre : MonoBehaviour
{
    public static AddOre instance;

    private void Awake()
    {
        instance = this;
    }


   public void PlusLeader()
    {
        Debug.Log("В табло!");
    }

}
