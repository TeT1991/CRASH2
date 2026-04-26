using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Renderer renderer;

    [Header(" Settings ")]
    [SerializeField] private float chainsawSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        renderer.materials[1].SetTextureOffset("_MainTex", Vector2.right * Time.time * chainsawSpeed);
    }
}
