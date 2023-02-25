using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public static float animationRunSpeed = 2.0f;
    private Animator characterAnimator;



    void Start()
    {

        characterAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        characterAnimator.SetFloat("RunSpeed", animationRunSpeed);
    }



    public void AnimateToPower()
    {
        StartCoroutine(PowerJumpDelay());
    }


    IEnumerator PowerJumpDelay()
    {
        Debug.Log("Coroutine started");

        Time.timeScale = 0; // Stop the game
        HUDManager.swipeEnabled = false;

        float holder = PlayerController.forwardSpeed;
        PowerUpManager.isNotAnimated = false;
        PlayerController.forwardSpeed = 0;

        GameObject objectMaleCharacter = GameObject.Find("MaleCharacter");
        Animator objectMaleAnimator = objectMaleCharacter.GetComponent<Animator>();
        objectMaleAnimator.SetTrigger("ActivatePowerJump");

        float pauseTime = Time.realtimeSinceStartup + 1.5f;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return null;
        }

        Debug.Log("Coroutine resumed");

        PlayerController.forwardSpeed = holder;

        Time.timeScale = 1.0f; // Resume the game
        HUDManager.swipeEnabled = true;

    }


}