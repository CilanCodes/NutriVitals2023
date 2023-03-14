using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private CharacterController characterController;
    private int desiredLane = 1;
    private Vector2 endTouchPosition;
    private Vector2 startTouchPosition;
    private Vector3 direction;
    public float laneDistance = 2.5f;
    public int smoothMovementSpeed = 30;
    public static float forwardSpeed = 150;
    public static float swipeSensitivity;
    public static Vector3 targetPosition;

    [SerializeField] private GameObject[] characterModels;
    private int characterIndex;


    void Start()
    {

        characterIndex = PlayerPrefs.GetInt("_characterIndex", 0);
        characterModels[characterIndex].SetActive(true);
        characterController = GetComponent<CharacterController>();

    }

    void Update()
    {

        if (StateManager.IsMoving)
        {

            direction.z = forwardSpeed;

            #region SWIPE LEFT AND RIGHT CODES

            if (Input.touchCount > 0 
                && Input.GetTouch(0).phase == TouchPhase.Began)

                startTouchPosition = Input.GetTouch(0).position;

            if (Input.touchCount > 0 
                && Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                endTouchPosition = Input.GetTouch(0).position;

                if (StateManager.EnergyState == StateManager.ENERGY.LOW_DANGER 
                    || StateManager.EnergyState == StateManager.ENERGY.HIGH_DANGER)
                {

                    #region WITH SWIPE SENSITIVITY

                    float swipeDistance = endTouchPosition.x - startTouchPosition.x;

                    if (swipeDistance > swipeSensitivity)

                        // Right Swipe
                        OnRightSwipe();

                    else if (swipeDistance < -swipeSensitivity)

                        // Left Swipe
                        OnLeftSwipe();

                    #endregion

                }

                else if (StateManager.EnergyState == StateManager.ENERGY.DRUNK)//FOR FUTURE UPDATE
                {

                    #region WITH REVERSE SWIPE SENSITIVITY

                    if (endTouchPosition.x > startTouchPosition.x)

                        //LeftSwipe
                        OnLeftSwipe();

                    else if (endTouchPosition.x < startTouchPosition.x)

                        //RightSwipe
                        OnRightSwipe();

                    #endregion

                }

                else
                {

                    #region NO SWIPE SENSITIVITY

                    if (endTouchPosition.x < startTouchPosition.x)

                        //LeftSwipe
                        OnLeftSwipe();

                    else if (endTouchPosition.x > startTouchPosition.x)

                        //RightSwipe
                        OnRightSwipe();

                    #endregion

                }

            }
            #endregion

            #region PLAYER MOVEMENT CALCULATION

            targetPosition =
                transform.position.z * transform.forward +
                transform.position.y * transform.up;

            if (desiredLane == 2)

                targetPosition += Vector3.right * laneDistance;

            else if (desiredLane == 0)

                targetPosition += Vector3.left * laneDistance;

            characterController.Move(direction * Time.deltaTime);
            transform.position = Vector3.Lerp(
                transform.position, 
                targetPosition, 
                smoothMovementSpeed * Time.deltaTime);
            characterController.center = characterController.center;

            #endregion

        }

        //BLOCKS ENERGY DECREMENT
        if (Time.timeScale == 0
            || StateManager.PowerUpTypeState == StateManager.POWER_UP_TYPE.GO
            || !StateManager.IsMoving)
        {

            HUDManager.ResetEnergyPoints();
            return;

        }

        //DECREASE ENERGY OVER TIME
        AdjustmentFunctions.DecreaseEnergyOverTime();

    }

    #region FOOD COLLIDER

    private void OnControllerColliderHit(ControllerColliderHit _controllerColliderHit)
    {

        string hit = _controllerColliderHit.transform.tag;
        StateManager.HitState = StateManager.GetHit(hit);

        if (StateManager.HitState != StateManager.HIT.JUNK)

            FindObjectOfType<SoundManager>().PlayEatGoodFood();

        else

            FindObjectOfType<SoundManager>().PlayEatBadFood();

        #region WITH POWER UP COLLIDER

        if (StateManager.PowerUpState == StateManager.POWER_UP.POWER_UP)
        {

            if (StateManager.PowerUpTypeState == StateManager.POWER_UP_TYPE.GO)
            {

                if (StateManager.HitState == StateManager.HIT.GO)

                    HUDManager.UpdateScoreEnergyPoints(25, 0f);

            }
            else if (StateManager.PowerUpTypeState == StateManager.POWER_UP_TYPE.GROW)
            {

                if (StateManager.HitState == StateManager.HIT.GROW)

                    FindObjectOfType<HUDManager>().healthBarFill.fillAmount += 0.1667f;

                else if (StateManager.HitState != StateManager.HIT.JUNK)
                    
                    AdjustmentFunctions.GoodFoodBenefits(1);

                else
                {

                    HUDManager.ResetFoodPoints();
                    HUDManager.UpdateScoreEnergyPoints(-100, 0.75f);

                }

            }
            else if (StateManager.PowerUpTypeState == StateManager.POWER_UP_TYPE.GLOW)
            {

                if (StateManager.HitState == StateManager.HIT.GLOW)

                    AdjustmentFunctions.GoodFoodBenefits(3);

                else if (StateManager.HitState != StateManager.HIT.JUNK)

                    AdjustmentFunctions.GoodFoodBenefits(2);

                else
                {

                    HUDManager.ResetFoodPoints();
                    HUDManager.UpdateScoreEnergyPoints(-100, 0.75f);

                }

            }
            else
            {

                if (StateManager.HitState != StateManager.HIT.JUNK)

                    AdjustmentFunctions.GoodFoodBenefits(1);

                else
                {

                    HUDManager.ResetFoodPoints();
                    HUDManager.UpdateScoreEnergyPoints(-100, 0.75f);

                }

            }

        }

        #endregion

        #region NO POWER UP COLLIDER

        else
        {

            if (StateManager.HitState != StateManager.HIT.JUNK)

                AdjustmentFunctions.GoodFoodBenefits(1);

            if (StateManager.HitState == StateManager.HIT.GO)

                HUDManager.UpdateFoodPoints(1, 0, 0);

            else if (StateManager.HitState == StateManager.HIT.GROW)

                HUDManager.UpdateFoodPoints(0, 1, 0);

            else if (StateManager.HitState == StateManager.HIT.GLOW)

                HUDManager.UpdateFoodPoints(0, 0, 1);

            else if (StateManager.HitState == StateManager.HIT.JUNK)
            {

                HUDManager.ResetFoodPoints();
                HUDManager.UpdateScoreEnergyPoints(-100, 0.75f);

            }

        }

        #endregion

        Destroy(_controllerColliderHit.gameObject);

    }

    #endregion

    private void OnRightSwipe()
    {

        desiredLane++;

        if (desiredLane == 3)
            
            desiredLane = 2;

    }

    private void OnLeftSwipe()
    {

        desiredLane--;

        if (desiredLane == -1)

            desiredLane = 0;

    }

}
