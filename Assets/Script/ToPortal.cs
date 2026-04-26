using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToPortal : MonoBehaviour
{
    public static ToPortal instance;

    public GameObject PortalOn;
    public int ToActivePortal;


    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(ToActivePortal == 0)
        {
            PortalOn.SetActive(true);
        }
    }
}
