using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject magnet;
    private CharacterController controller;
    private Vector3 direciton;
    public float forwardSpeed;
    public float maxSpeed;

    public float jumpForce;
    public float mushroomForce;

    public float gravity =-20f;

    private bool hasDino;
    private int desiraedLane = 1;
    public float laneDistance = 4; //diffrance btwen lanes
    void Start()
    {
        controller = GetComponent<CharacterController>();
        hasDino = false;
    }


    void Update()
    {
        if (!PlayerManager.gameStarted) { return; }
        if (controller.isGrounded!)
        {direciton.y += gravity * Time.deltaTime;}

        direciton.y += gravity * Time.deltaTime;
        direciton.z = forwardSpeed;
        if (forwardSpeed < maxSpeed) {
            forwardSpeed += (float)0.1 * Time.deltaTime;
        }

        //getting inputs for lane 
        if (SwipeManager.swipeRight)
        {
            desiraedLane++;
            if (desiraedLane == 3)
            {
                desiraedLane = 2;
            }

        }
        if (SwipeManager.swipeLeft)
        {
            desiraedLane--;
            if (desiraedLane == -1)
            {
                desiraedLane = 0;
            }
        }
        if (SwipeManager.swipeUp && controller.isGrounded)
        {
            Jump();
        }
        //calculating LanePosition
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiraedLane == 0) {
            targetPosition += Vector3.left * laneDistance;
        }
        if (desiraedLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        controller.Move(direciton * Time.deltaTime);
        //moving to desiredlane
        transform.position = Vector3.Lerp(transform.position, targetPosition, 10 * Time.fixedDeltaTime);
    }
    private void Jump()
    {
        direciton.y = jumpForce;
    }
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Shield"))
        {
            hasDino = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Mushroom"))
        {
            direciton.y = mushroomForce;
        }
        if (collision.gameObject.CompareTag("Magnet"))
        {
            magnet.SetActive(true);
            magnet.GetComponent<CoinAtractor>().magnetTimer = magnet.GetComponent<CoinAtractor>().magnetDuration;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (!hasDino)
            {
                PlayerManager.gameOver = true;
            }
            else
            {
                hasDino = false;
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            PlayerManager.coinCount++;
            Destroy(collision.gameObject);
        }
    }

    /*
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Dino"))
        {
            hasDino = true;
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            if (!hasDino)
            {
                PlayerManager.gameOver = true;
            }
            else
            {
                hasDino = false;
                Destroy(hit.gameObject);
            }

        }
        if (hit.gameObject.CompareTag("Coin"))
        {
            PlayerManager.coinCount++;
            Destroy(hit.gameObject);
        }
    }
    */
}
