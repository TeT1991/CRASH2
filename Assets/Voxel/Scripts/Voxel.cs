using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetSystems;

public class Voxel : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Renderer renderer;
    [SerializeField] private Collider collider;
    private MeshFilter filter;
    private bool isCollected;

    private GameObject collectionZone;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        filter = renderer.GetComponent<MeshFilter>();
    }

    private void Update()
    {
        if (isCollected)
            MoveTowardsCollectionZone();
    }

    public void Configure(float voxelScale, Material material)
    {
        transform.localScale = voxelScale * Vector3.one;
        renderer.material = material;
    }

    public void Colorize(Material material)
    {
        renderer.material = material;
    }

    public void Collect()
    {
        //collider.enabled = false;
        isCollected = true;

        collectionZone = GameObject.Find("Collection Zone");
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
        transform.position = transform.position.With(z: 0);

        Taptic.Light(); 
    }

    public void DisableCollider()
    {
        collider.enabled = false;
    }

    public bool IsCollected()
    {
        return isCollected;
    }

    private void MoveTowardsCollectionZone()
    {
        float targetX = collectionZone.transform.position.x;
        float xDiff = targetX - transform.position.x;

        rigidbody.velocity = rigidbody.velocity.With(x: xDiff);
    }

}
