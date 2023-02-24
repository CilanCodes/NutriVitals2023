using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 direction;
    public static float forwardSpeed = 150;

    private int desiredLane = 1; // 0-left, 1-middle, 2-right
    public float laneDistance = 2.5f;
    public int smoothMovementSpeed = 30;

    public static float swipeSensitivity;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    public static Vector3 targetPosition;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        direction.z = forwardSpeed;

        #region ARROW BUTTON CODES
        //arrow buttons
        /*        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight )
                {
                    desiredLane++;
                    if (desiredLane == 3)
                    {
                        desiredLane = 2;
                    }
                }*/

        /*        if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft )
                {
                    desiredLane--;
                    if (desiredLane == -1)
                    {
                        desiredLane = 0;
                    }
                }*/
        #endregion

        #region SWIPE LEFT AND RIGHT CODES

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (HUDManager.energyStatus == "LOW DANGER") { 
                #region WITH SWIPE SENSITIVITY

                float swipeDistance = endTouchPosition.x - startTouchPosition.x;

                if (swipeDistance > swipeSensitivity && HUDManager.swipeEnabled)
                {
                    // Right Swipe
                    desiredLane++;

                    if (desiredLane == 3)
                    {
                        desiredLane = 2;
                    }
                }
                else if (swipeDistance < -swipeSensitivity && HUDManager.swipeEnabled)
                {
                    // Left Swipe
                    desiredLane--;

                    if (desiredLane == -1)
                    {
                        desiredLane = 0;
                    }
                }

                #endregion
            }

            else if (HUDManager.energyStatus == "HIGH DANGER")
            {
                #region WITH REVERSE SWIPE SENSITIVITY

                if ((endTouchPosition.x > startTouchPosition.x) && HUDManager.swipeEnabled)
                {
                    //LeftSwipe
                    desiredLane--;

                    if (desiredLane == -1)
                    {
                        desiredLane = 0;

                    }

                }
                else if ((endTouchPosition.x < startTouchPosition.x) && HUDManager.swipeEnabled)
                {
                    //RightSwipe
                    desiredLane++;

                    if (desiredLane == 3)
                    {
                        desiredLane = 2;
                    }
                }

                #endregion
            }

            else
            {
                #region NO SWIPE SENSITIVITY
                if ((endTouchPosition.x < startTouchPosition.x) && HUDManager.swipeEnabled)
                {
                    //LeftSwipe
                    desiredLane--;

                    if (desiredLane == -1)
                    {
                        desiredLane = 0;

                    }

                }
                else if ((endTouchPosition.x > startTouchPosition.x) && HUDManager.swipeEnabled)
                {
                    //RightSwipe
                    desiredLane++;

                    if (desiredLane == 3)
                    {
                        desiredLane = 2;
                    }
                }
                #endregion
            }
        }
        #endregion

        #region PLAYER MOVEMENT CALCULATION

        targetPosition =
            transform.position.z * transform.forward +
            transform.position.y * transform.up;


        if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        else if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }


        controller.Move(direction * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothMovementSpeed * Time.deltaTime);
        controller.center = controller.center;

        #endregion

        
        if (Time.timeScale == 0)
            return;

        //DECREASE ENERGY OVER TIME
        HUDManager.UpdateScoreEnergyPoints(0, -.00075f);

    }

    #region FOOD COLLIDER

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Go" || hit.transform.tag == "Grow" || hit.transform.tag == "Glow")
        {
            // GENERAL GOOD FOOD BENEFITS
            HUDManager.UpdateScoreEnergyPoints(50, .025f);


            // GO GROW GLOW COUNTERS
            switch (hit.transform.tag)
            {
                case "Go":
                    HUDManager.UpdateFoodPoints(1, 0, 0);
                    break;

                case "Grow":
                    HUDManager.UpdateFoodPoints(0, 1, 0);
                    break;

                case "Glow":
                    HUDManager.UpdateFoodPoints(0, 0, 1);
                    break;

            }
        }
        else if (hit.transform.tag == "Junk")
        {
            HUDManager.ResetFoodPoints();
            HUDManager.UpdateScoreEnergyPoints(-100, 0.5f);
        }



        Destroy(hit.gameObject);
    }

    #endregion

}
