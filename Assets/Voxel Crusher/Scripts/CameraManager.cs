using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Robot robot;

    [Header(" Settings ")]
    [SerializeField] private Vector3 sideOffset;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GetTargetPosition();
    }

    private Vector3 GetTargetPosition()
    {
        Vector3 offset = (robot.GetChainLength() - 3) * sideOffset;
        return initialPosition + offset;
    }
}
