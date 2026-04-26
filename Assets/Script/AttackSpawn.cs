using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawn : MonoBehaviour
{

    public GameObject AtackSpawner;

    public void SpawnAttack()
    {
        Instantiate(AtackSpawner, transform.position, transform.rotation);
    }

}
