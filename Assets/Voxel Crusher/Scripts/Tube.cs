using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetSystems;

public class Tube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Voxel voxel))
            VoxelHitCallback(voxel);
    }

    private void VoxelHitCallback(Voxel voxel)
    {
        Destroy(voxel.gameObject);

        UIManager.AddCoins(1);
        LavaFloor.instance.LBKillScore += 1;
    }
}
