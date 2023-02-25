using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    public static string powerupStatus; //NONE, POWER UP
    public static string typeOfPowerUp; //GO, GROW, GLOW
    public static bool isNotAnimated;

    private CharacterAnimationController characterAnimationController; //animation class holder


    private void Start()
    {
        characterAnimationController = FindObjectOfType<CharacterAnimationController>(); //reference it
    }


    private void Update()
    {

        //POWERUP
        if (HUDManager.goPoints == 5 || HUDManager.growPoints == 5 || HUDManager.glowPoints == 5)
        {
            if(isNotAnimated)
                characterAnimationController.AnimateToPower();


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

}