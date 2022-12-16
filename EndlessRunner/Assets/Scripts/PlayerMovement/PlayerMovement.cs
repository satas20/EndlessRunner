using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direciton;
    public float forwardSpeed;

    private int desiraedLane = 1;
    public float laneDistance = 4; //diffrance btwen lanes
    void Start()
    {
        controller = GetComponent<CharacterController>();
       
    }

   
    void Update()
    {
        direciton.z = forwardSpeed;
        //getting inputs for lane 
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            desiraedLane++;
            if (desiraedLane == 3) 
            {
                desiraedLane = 2;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiraedLane--;
            if (desiraedLane == -1)
            {
                desiraedLane = 0;
            }
        }
        //calculating LanePosition
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiraedLane == 0){
            targetPosition += Vector3.left * laneDistance;
        }
        if (desiraedLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        controller.Move(direciton * Time.deltaTime);
        //moving to desiredlane
        transform.position = Vector3.Lerp(transform.position, targetPosition,10*Time.fixedDeltaTime);
    }
   
}
