using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoxelEffector : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private LayerMask voxelLayer;
    [SerializeField] private float radius;
    private bool isActive;

    private Vector3 detectionBoxHalfExtents;
    private Voxel detectedVoxel;

    [Header(" Events ")]
    public static UnityAction onVoxelCollectedEvent;
    public static UnityAction<Transform> OnVoxelStructureCompleted;

    // Start is called before the first frame update
    void Start()
    {
        detectionBoxHalfExtents = new Vector3(radius / 2, radius / 2, .1f);
    }

    // Update is called once per frame

    void Update()
    {
        if(!isActive)
            return;


        //Collider[] voxels = Physics.OverlapSphere(transform.position, radius, voxelLayer);
        Collider[] voxels = Physics.OverlapBox(transform.position, detectionBoxHalfExtents, transform.rotation, voxelLayer);

        for (int i = 0; i < voxels.Length; i++)
            if(voxels[i].TryGetComponent(out detectedVoxel))
                if(!detectedVoxel.IsCollected())
                    CollectVoxel(voxels[i].gameObject);            
    }

    private void CollectVoxel(GameObject voxel)
    {

        voxel.AddComponent<Rigidbody>();
        voxel.GetComponent<Rigidbody>().velocity = Random.onUnitSphere;

        voxel.GetComponent<Voxel>().Collect();

        // At this point, check if this was the last voxel
        if(voxel.transform.parent.childCount <= 1)
            LastVoxelCollected(voxel.transform.parent);

        voxel.transform.SetParent(null);

        //Destroy(voxel, 2);


        //LeanTween.delayedCall(voxel, 1f, () => MoveVoxelTowardsPlayer(voxel));

        //onVoxelCollectedEvent?.Invoke();
    }

    private void MoveVoxelTowardsPlayer(GameObject voxel)
    {
        Destroy(voxel.GetComponent<Rigidbody>());
    }

    public void Enable()
    {
        isActive = true;
    }

    public void Disable()
    {
        isActive = false;
    }
    
    private void LastVoxelCollected(Transform voxelStructure)
    {
        OnVoxelStructureCompleted?.Invoke(voxelStructure);
    }


    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
