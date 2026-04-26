using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RobotController : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Robot robot;
    [SerializeField] private RobotFuel robotFuel;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform orientationParent;
    private Vector3 targetInitialPosition;
    
    [Header(" Settings ")]
    [Range(0f, 1f)]
    [SerializeField] private float movementLerp;
    [SerializeField] private float moveSpeed;
    private Vector3 clickedTargetPosition;


    [Header(" Events ")]
    public static Action OnRobotBeingUsed;

    /*
    [Header(" Horizontal Movement ")]
    [SerializeField] private float maxLocalX;
    [SerializeField] private float maxXVelocity;
    [SerializeField] private float xMovementFrequency;
    */

    // Start is called before the first frame update
    void Start()
    {
        targetInitialPosition = targetTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if(!IsControlled())
            //targetTransform.position = Vector3.Lerp(targetTransform.position, targetInitialPosition, .1f);
    }

    public void MouseDownCallback()
    {
        targetTransform.GetComponent<Rigidbody>().isKinematic = false;
        clickedTargetPosition = targetTransform.position;
    }

    public void MouseDragCallback(Vector2 mouseDelta)
    {

        if (!robotFuel.HasFuel())
            return;

        Vector3 velocity = new Vector3(0, mouseDelta.y, mouseDelta.x);
        Vector3 worldVelocity = orientationParent.TransformVector(velocity);


        Vector3 moveDelta = worldVelocity * Time.deltaTime;

        Vector3 targetPosition = targetTransform.position + moveDelta;
      
        float targetRobotLength = Vector3.Distance(targetPosition, transform.position);


        OnRobotBeingUsed?.Invoke();

        if (targetRobotLength > robot.GetMaxLength())
        {
            Vector3 direction = (targetTransform.position - transform.position).normalized;
            
            targetTransform.GetComponent<Rigidbody>().velocity = -.1f * direction;
            return;
        }


        if(targetRobotLength > robot.GetMaxLength())
            velocity = Vector3.zero;


        float angle = orientationParent.localEulerAngles.y;
        if(angle >= 90 && angle <= 270)
            velocity.z *= -1;

        targetTransform.GetComponent<Rigidbody>().velocity = worldVelocity * moveSpeed;
        
        
        
        Vector3 targetLocalPos = targetTransform.localPosition;
        targetLocalPos.x = 0;
        targetTransform.localPosition = targetLocalPos;
        

        return;
    }

    public void MouseUpCallback()
    {
        targetTransform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetTransform.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Stop()
    {
        targetTransform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        targetTransform.GetComponent<Rigidbody>().isKinematic = true;
    }

    private bool IsControlled()
    {
        return !targetTransform.GetComponent<Rigidbody>().isKinematic;
    }
}
