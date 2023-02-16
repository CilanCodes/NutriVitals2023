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

    public float effectDuration = 10f;

    private float timeLeft;
    private bool isPowerUpActive;

    private bool growPowerUpImmunitySwitch = false;
    private bool glowPowerUpEffect = false;
    
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

        if (desiredLane == 0) {
            targetPosition += Vector3.left * pathDistance;
        } else if (desiredLane == 2) {
            targetPosition += Vector3.right * pathDistance;
        }

        if (forwardSpeed > 100) {
            forwardSpeed = 100;
        }
        if ((forwardSpeed <= 20 && isPowerUpActive == false) || (forwardSpeed >= 80 && isPowerUpActive == false)) {
            FindObjectOfType<AudioManager>().PlaySound("GameOverFX");
            PlayerManager.gameOver = true;
        }

        transform.position = targetPosition;
        controller.center = controller.center;
        speedBarValue = forwardSpeed;

        if (isPowerUpActive)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0f)
            {
                DeactivateGoPowerUp();
                DeactivateGrowPowerUp();
                DeactivateGlowPowerUp();
            }
        }
    }
        

    private void FixedUpdate() {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Go") {
            FindObjectOfType<AudioManager>().PlaySound("FoodEat");
            if (glowPowerUpEffect == true){
                PlayerManager.gameScore += 150;
            } else {
                PlayerManager.gameScore += 50; 
            }
            if (isPowerUpActive == false) {
                forwardSpeed += 2f;
                PlayerManager.goCount += 1;
            }
            if (PlayerManager.goCount == 5) {
                FindObjectOfType<AudioManager>().PlaySound("PowerUp");
                PlayerManager.goCount = 0;
                PlayerManager.growCount = 0;
                PlayerManager.glowCount = 0;
                ActivateGoPowerUp();
            }
        }
        else if(other.tag == "Grow") {
            FindObjectOfType<AudioManager>().PlaySound("FoodEat");
            if (glowPowerUpEffect == true){
                PlayerManager.gameScore += 150;
            } else {
                PlayerManager.gameScore += 50; 
            }
            if (isPowerUpActive == false) {
                forwardSpeed += 2f;
                PlayerManager.growCount += 1;
            }
            if (PlayerManager.growCount == 5) {
                FindObjectOfType<AudioManager>().PlaySound("PowerUp");
                PlayerManager.goCount = 0;
                PlayerManager.growCount = 0;
                PlayerManager.glowCount = 0;
                ActivateGrowPowerUp();
            }
        }
        else if(other.tag == "Glow") {
            FindObjectOfType<AudioManager>().PlaySound("FoodEat");
            if (glowPowerUpEffect == true){
                PlayerManager.gameScore += 150;
            } else {
                PlayerManager.gameScore += 50; 
            }
            if (isPowerUpActive == false) {
                forwardSpeed += 2f;
                PlayerManager.glowCount += 1;
            }
            if (PlayerManager.glowCount == 5) {
                FindObjectOfType<AudioManager>().PlaySound("PowerUp");
                PlayerManager.goCount = 0;
                PlayerManager.growCount = 0;
                PlayerManager.glowCount = 0;
                ActivateGlowPowerUp();
            }
        }
        
        else if(other.tag == "JunkFoods" && growPowerUpImmunitySwitch == false) {
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            PlayerManager.gameScore -= 25;
            forwardSpeed -= 20f;
        }

        if(PlayerManager.gameOver == true){
        }
    }
    
    private void ActivateGoPowerUp() {
        isPowerUpActive = true;
        timeLeft = effectDuration;

        // apply power-up effect here
        forwardSpeed = forwardSpeed * 3;
    }

    private void DeactivateGoPowerUp() {
        isPowerUpActive = false;

        // remove power-up effect here
        forwardSpeed = forwardSpeed / 2;
    }

    private void ActivateGrowPowerUp() {
        isPowerUpActive = true;
        growPowerUpImmunitySwitch = true;
        timeLeft = effectDuration;

        float yScale = 2.5f;
        float xScale = 2;
        transform.localScale = new Vector3(xScale, yScale, transform.localScale.z);
    }

    private void DeactivateGrowPowerUp() {
        isPowerUpActive = false;
        growPowerUpImmunitySwitch = false;

        float yScale = 1.5f;
        float xScale = 1.5f;
        transform.localScale = new Vector3(xScale, yScale, transform.localScale.z);
    }

    private void ActivateGlowPowerUp() {
        isPowerUpActive = true;
        glowPowerUpEffect = true;
        timeLeft = effectDuration;

        // apply power-up effect here
        
        
    }

    private void DeactivateGlowPowerUp() {
        isPowerUpActive = false;
        glowPowerUpEffect = false;
    }

}



