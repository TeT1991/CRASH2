using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelCashConverter : MonoBehaviour
{
    //[Header(" Elements ")]
    //[SerializeField] private VoxToCashMachine voxToCashMachine;

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
        Destroy(other.gameObject);

        /*
        PlayerTrader.instance.PurchaseDiamonds(1, 1, true);
        voxToCashMachine.GetComponent<DiamondThrower>().ThrowDiamonds(1);
        */
    }
}
