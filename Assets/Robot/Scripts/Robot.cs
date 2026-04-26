using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzelGames.FastIK;

public class Robot : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform pivotsParent;
    [SerializeField] private RobotArm robotArmPrefab;
    [SerializeField] private Transform robotTarget;
    [SerializeField] private Transform pivotRendererPrefab;
    private Transform lastPivot;    

    [Header(" Settings ")]
    [Tooltip("Determines the length of the robot arm")]
    [SerializeField] private Vector3 initialPivotOffset;
    private int chainLength;
    private bool initialized;



    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Initialize();

        if(Input.GetKeyDown(KeyCode.A))
            AddArm();
    }

    private void Initialize()
    {
        Transform currentPivot = pivotsParent.GetChild(0);

        if(currentPivot == null)
            return;

        int index = 0;
        chainLength = 0;
        
        // 1. Set the pivot's positions
        while(currentPivot.childCount > 0)
        {
            // Position the pivots
            Vector3 localPosition = Vector3.up * index * initialPivotOffset.y + Vector3.forward * (index % 2 == 0 ? 0 : initialPivotOffset.z);
            currentPivot.position = transform.TransformPoint(localPosition); 
            index++;

            // Increase the chain length
            chainLength++;

            currentPivot = currentPivot.GetChild(0);
        }

        // Set the position of the last pivot
        Vector3 lastLocalPos = Vector3.up * index * initialPivotOffset.y + Vector3.forward * (index % 2 == 0 ? 0 : initialPivotOffset.z); 
        currentPivot.position = transform.TransformPoint(lastLocalPos);

        // Reset the current pivot for the configuration loop
        currentPivot = pivotsParent.GetChild(0);

        int armIndex = 0;

        while(currentPivot.childCount > 0)
        {
            // Destroy the renderer if any
            while(currentPivot.childCount > 1)
            {
                Transform t = currentPivot.GetChild(1);
                t.SetParent(null);
                Destroy(t.gameObject);
            }
            
            /*
            if(currentPivot.childCount > 1)
                Destroy(currentPivot.GetChild(1).gameObject);
            */

            float armScale = Mathf.Lerp(.5f, 1f, (1f - ((float)armIndex / (chainLength - 1))));

            CreatePivotRenderer(currentPivot);
            CreateArmRenderer(currentPivot, currentPivot.GetChild(0), armScale);
            currentPivot = currentPivot.GetChild(0);

            lastPivot = currentPivot;

            armIndex++;
        }              

        robotTarget.position = lastPivot.position;

        // Initialize the IK solver
        FastIKFabric fastIKSolver = lastPivot.GetComponent<FastIKFabric>();

        if(fastIKSolver == null)
            fastIKSolver = lastPivot.gameObject.AddComponent<FastIKFabric>();

        fastIKSolver.Configure(chainLength, robotTarget);
        fastIKSolver.Init();

        initialized = true;
    }

    private void CreateArmRenderer(Transform from, Transform to, float armScale)
    {
        Vector3 center = (from.position + to.position) / 2;
        float length = Vector3.Distance(from.position, to.position);
        Vector3 direction = (to.position - from.position).normalized;

        RobotArm robotArmInstance = Instantiate(robotArmPrefab, center, Quaternion.identity, from);
        robotArmInstance.SetLength(length);
        robotArmInstance.SetScale(armScale);
        robotArmInstance.transform.up = direction;
    }

    private void CreatePivotRenderer(Transform parent)
    {
        Instantiate(pivotRendererPrefab, parent.transform.position, parent.rotation * Quaternion.identity, parent);
    }

    public void AddArm(bool saveData = true)
    {
        // 1. Create a new pivot, child of the last pivot
        GameObject newPivot = new GameObject("Pivot ");
        newPivot.transform.SetParent(lastPivot);
        newPivot.transform.localRotation = Quaternion.identity;

        Destroy(lastPivot.GetComponent<FastIKFabric>());

        Initialize();
    }

    public void RemoveArm()
    {

    }

    public float GetMaxLength()
    {
        return GetComponentInChildren<FastIKFabric>().GetCompleteLength() - .1f;
    }

    public int GetChainLength()
    {
        return chainLength;
    }

    public bool IsInitialized()
    {
        return initialized;
    }
}
