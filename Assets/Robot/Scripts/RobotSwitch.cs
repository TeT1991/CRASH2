using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class RobotSwitch : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Robot robot;
    [SerializeField] private CinemachineVirtualCamera voxelCamera;
    [SerializeField] private GameObject robotCanvas;
    [SerializeField] private VoxelEffector[] voxelEffectors;
    [SerializeField] private EpicToonFX.ETFXRotation sawRotation;

    [Header(" Events ")]
    public static UnityAction<RobotSwitch> OnRobotDisabled;

    // Start is called before the first frame update
    void Start()
    {
        robotCanvas.SetActive(false);

        Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enable()
    {
        robot.GetComponent<JetSystems.SlideInput>().enabled = true;

        sawRotation.enabled = true;

        foreach(VoxelEffector ve in voxelEffectors)
            ve.Enable();
    
        robotCanvas.SetActive(true);
    }

    public void Disable()
    {
        robot.GetComponent<JetSystems.SlideInput>().enabled = false;

        foreach(VoxelEffector ve in voxelEffectors)
            ve.Disable();

        sawRotation.enabled = false;

        robotCanvas.SetActive(false);

        robot.GetComponent<RobotController>().Stop();

        OnRobotDisabled?.Invoke(this);
    }
    }
