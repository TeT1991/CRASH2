using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArm : MonoBehaviour
{
    [Header(" Renderers ")]
    [SerializeField] private GameObject[] armRenderers;

    // Start is called before the first frame update
    void Start()
    {
        DisplayRandomArm();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayRandomArm()
    {
        int randomIndex = Random.Range(0, armRenderers.Length);

        for (int i = 0; i < armRenderers.Length; i++)
            armRenderers[i].SetActive(i == randomIndex);           
    }

    public void SetLength(float length)
    {
        Vector3 scale = transform.localScale;
        scale.y = length / 2;
        transform.localScale = scale;
    }

    public void SetScale(float scale)
    {
        Vector3 s = transform.localScale;
        s.x = scale;
        s.z = scale;
        transform.localScale = s;
    }
    
}
