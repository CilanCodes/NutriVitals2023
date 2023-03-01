using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{

    public static string powerupStatus; //NONE, POWER UP
    public static string typeOfPowerUp; //GO, GROW, GLOW
    public static bool isNotAnimated;

    [SerializeField] public GameObject powerUpRaysImage;
    [SerializeField] public GameObject powerUpOverlayStatus;
    [SerializeField] public Sprite powerupSprite;
    [SerializeField] public Sprite dangerSprite;

    private CharacterAnimationController characterAnimationController; //animation class holder
    private Image overlayStatusImage;
    private GameManager gameManager;

    private void Start()
    {
        characterAnimationController = FindObjectOfType<CharacterAnimationController>(); //reference it
        typeOfPowerUp = "NONE";
        powerupStatus = "NONE";

        overlayStatusImage = powerUpOverlayStatus.GetComponent<Image>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    private void Update()
    {
        if (powerupStatus == "POWER UP")
        {
            overlayStatusImage.sprite = powerupSprite;
            powerUpRaysImage.SetActive(true);
        }
        else if (powerupStatus == "NONE")
        {
            //gameManager.GetAnimator.SetTrigger("InActivateOverlayStatus");
            overlayStatusImage.sprite = dangerSprite;
            powerUpRaysImage.SetActive(false);
        }

        //POWERUP
        if (HUDManager.goPoints == 5 || HUDManager.growPoints == 5 || HUDManager.glowPoints == 5)
        {
            if(isNotAnimated)
                characterAnimationController.AnimateToPower();

            StartCoroutine(PowerUpDurationThreeSeconds());


            if (HUDManager.goPoints == 5)
            {
                GoPowerUp();
            }
            else if (HUDManager.growPoints == 5)
            {
                GrowPowerUp();
            }
            else if (HUDManager.glowPoints == 5)
            {
                GlowPowerUp();
            }
            HUDManager.ResetFoodPoints();

        }
        else
        {
            isNotAnimated = true;
        }



    }

    #region GO POWER UP
    public static void GoPowerUp()
    {
        powerupStatus = "POWER UP";
        typeOfPowerUp = "GO";
        
    }

    #endregion

    #region GROW POWER UP
    public static void GrowPowerUp()
    {
        powerupStatus = "POWER UP";
        typeOfPowerUp = "GROW";

    }

    #endregion

    #region GLOW POWER UP
    public static void GlowPowerUp()
    {
        powerupStatus = "POWER UP";
        typeOfPowerUp = "GLOW";

    }

    #endregion

    #region SPECIAL  POWER UPS

    #endregion

    #region POWER UP RESET AFTER 3 SECONDS
    private static IEnumerator PowerUpDurationThreeSeconds()
    {
        yield return new WaitForSeconds(5f);
        typeOfPowerUp = "NONE";

        yield return new WaitForSeconds(3f);
        powerupStatus = "NONE";
    }
        #endregion

    }