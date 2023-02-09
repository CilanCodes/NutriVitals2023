using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float increaseSpeed;

    private int desiredLane = 1;
    public float pathDistance = 2;
    
    public static float speedBarValue;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
        PlayerManager.speed = forwardSpeed;

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if(desiredLane == 3)
               desiredLane = 2;
        }

        if (SwipeManager.swipeLeft) 
        {
            desiredLane--;
            if(desiredLane == -1)
               desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0){
            targetPosition += Vector3.left * pathDistance;
        } else if (desiredLane == 2){
            targetPosition += Vector3.right * pathDistance;
        }

        if (forwardSpeed > 100){
            forwardSpeed = 100;
        }

        if (forwardSpeed <= 20 || forwardSpeed >= 80){
            PlayerManager.gameOver = true;
        }

        transform.position = targetPosition;
        controller.center = controller.center;
        speedBarValue = forwardSpeed;
    }
        

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Go" || other.tag == "Grow" || other.tag == "Glow"){
            if(other.tag == "Go"){
                PlayerManager.goCount += 1;
            }
            else if(other.tag == "Grow"){
                PlayerManager.growCount += 1;
            }
            else if(other.tag == "Glow"){
                PlayerManager.glowCount += 1;
            }
            PlayerManager.gameScore += 20;
            forwardSpeed += 2f;
        }

        if(other.tag == "JunkFoods"){
            PlayerManager.gameScore -= 40;
            forwardSpeed -= 10f;
        }
    }
}



