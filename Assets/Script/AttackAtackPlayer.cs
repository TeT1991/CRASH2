using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAtackPlayer : MonoBehaviour
{
    public GameObject Saw;
    public GameObject PlayerPos;
    void Start()
    {
        PlayerPos = GameObject.Find("PLAYER");
    }

    // Update is called once per frame
    void Update()
    {
        Saw.transform.position = PlayerPos.transform.position;
    }
}
