using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HUDManager : MonoBehaviour
{

    public static int scorePoints;
    public static float energyPoints;
    public static float healthPoints;
    public static int goPoints;
    public static int growPoints;
    public static int glowPoints;
    public static bool swipeEnabled;
    public static string energyStatus;

    [SerializeField] private Image energyBarFill;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private TextMeshProUGUI scoreTextPoints;
    [SerializeField] private TextMeshProUGUI gameOverTextPoints;
    [SerializeField] private TextMeshProUGUI goTextPoints;
    [SerializeField] private TextMeshProUGUI growTextPoints;
    [SerializeField] private TextMeshProUGUI glowTextPoints;

    [SerializeField] private GameObject gameOverPanel;

    private float timeSinceLastDecrease = 0f;
    [SerializeField] private float decreaseSpeed = 2f;
    [SerializeField] private const float decreaseInterval = 4f;

    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        ResetAllPoints();
        StartCoroutine(EnableSwipeAfterDelay());
        Debug.Log(healthPoints);

        scorePoints = 1450;// this for testing maps : RESET THIS BACK TO 0 BEFORE DEPLOY

        gameManager.GetAnimator.SetTrigger("InActivateOverlayStatus");
    }

    private void Update()
    {

        //Prevent Update() from continuing even if the game is paused
        if (Time.timeScale == 0)
            return;

        #region UPDATE HUD ELEMENTS

        energyBarFill.fillAmount = Mathf.Lerp(energyBarFill.fillAmount, energyPoints, Time.deltaTime * 3f);

        scoreTextPoints.text = scorePoints.ToString();
        gameOverTextPoints.text = scorePoints.ToString();

        
        if(PowerUpManager.typeOfPowerUp == "GO")
        {
            goTextPoints.text = "5";
            growTextPoints.text = growPoints.ToString();
            glowTextPoints.text = glowPoints.ToString();
        }
        else
        {
            goTextPoints.text = goPoints.ToString();
            growTextPoints.text = growPoints.ToString();
            glowTextPoints.text = glowPoints.ToString();
        }
        

        

        #endregion

        #region MONITORED ENERGY LEVEL 

        #region ENERGY GUIDES
        //ENERGY STATUS: LOW DANGER / HIGH DANGER / LOW WARNING / HIGH WARNING / 
        //LR: 0 <= n &&  n <= 0.17          \\ 0 - 0.17
        //LY: 0.17 < n && n <= 0.37         \\ 0.171 - 0.37
        //G : 0.37 < n && n <= 0.635        \\ 0.371 - 0.635
        //HY: 0.635 < n && n <= 0.835       \\ 0.6351 - 0.835
        //HR: 0.835 < n && n <= 1           \\ 0.835 - 0.8351
        #endregion

        #region DANGER LEVELS

        if (( 0 <= energyBarFill.fillAmount && energyBarFill.fillAmount <= .17) || ( .835 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 1))
        {
            DecreaseHealthBar();

            //LOW ENERGY LEVEL
            if (0 <= energyBarFill.fillAmount && energyBarFill.fillAmount <= .17)
            {
                energyStatus = "LOW DANGER";
                PlayerController.swipeSensitivity = 150f;
                PlayerController.forwardSpeed = 80;
                CharacterAnimationController.animationRunSpeed = 0.4f;
            }

            //HIGH ENERGY LEVEL
            if (.835 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 1)
            {
                energyStatus = "HIGH DANGER";
                PlayerController.swipeSensitivity = 0.5f;
                PlayerController.forwardSpeed = 300;
                CharacterAnimationController.animationRunSpeed = 2f;
            }

        }

        #endregion

        #region HEALTHY / WARNING LEVELS
        else
        {
            gameManager.GetAnimator.SetTrigger("InActivateOverlayStatus");

            //WARNING / YELLOW ENERGY LEVEL
            if ((0.17 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 0.37) || (0.635 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 0.835))
            {
                //LOW LEVEL WARNING
                if(0.17 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 0.37)
                {
                    energyStatus = "LOW WARNING";
                    PlayerController.forwardSpeed = 130;
                    CharacterAnimationController.animationRunSpeed = 0.7f;
                }
                //HIGH LEVEL WARNING
                if (0.635 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 0.835)
                {
                    energyStatus = "HIGH WARNING";
                    PlayerController.forwardSpeed = 170;
                    CharacterAnimationController.animationRunSpeed = 1.5f;
                }


            }

            //HEALTHY / GREEN ENERGY LEVEL
            if (0.37 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 0.635)
            {
                energyStatus = "BALANCED";
                PlayerController.forwardSpeed = 150;
                CharacterAnimationController.animationRunSpeed = 1;
            }

        }
        #endregion

        #endregion

        #region CHECK IF HEALTH IS 0

        if (healthBarFill.fillAmount <= 0)
        {
            GameOver();
        }

        #endregion


        

    }

    #region UPDATE FUNCTIONS
    public static void UpdateFoodPoints(int go, int grow, int glow)
    {

        goPoints += go;
        growPoints += grow;
        glowPoints += glow;
    }

    public static void UpdateScoreEnergyPoints(int score, float energy)
    {

        //Determines if the score or energy reaches negative, if so reset the value to 0
        if (scorePoints >= 0)
        {
            if ((scorePoints + score) < 0)
            {
                score = 0;
                scorePoints = 0;
            }
            else
            {
                scorePoints += score;
            }

        }

        if (energyPoints >= 0)
        {
            if ((energyPoints + energy) < 0)
            {
                energy = 0;
                energyPoints = 0;
            }
            else if ((energyPoints + energy) > 1)
            {
                energy = 1.0005f;
                energyPoints = 1.0005f;
            }
            else
            {
                energyPoints += energy;
            }

        }

    }
    #endregion

    #region RESET FUNCTIONS
    public static void ResetAllPoints()
    {
        scorePoints = 0;
        ResetFoodPoints();
        ResetEnergyPoints();
    }

    public static void ResetFoodPoints()
    {
        goPoints = 0;
        growPoints = 0;
        glowPoints = 0;
    }

    public static void ResetEnergyPoints()
    {
        energyPoints = 0.5f;
    }
    #endregion

    #region HEALTH BAR ADJUSTMENT
    //SMOOTH HEALTH BAR
    private void DecreaseHealthBar()
    {
        gameManager.GetAnimator.SetTrigger("ActiveOverlayStatus");

        timeSinceLastDecrease += Time.deltaTime;

        if (timeSinceLastDecrease >= decreaseInterval && healthBarFill.fillAmount > 0)
        {
            float targetFillAmount = healthBarFill.fillAmount - 0.1667f;
            StartCoroutine(DecreaseHealthBarSmoothly(targetFillAmount, decreaseSpeed));
            timeSinceLastDecrease = 0f;
        }
    }

    private IEnumerator DecreaseHealthBarSmoothly(float targetFillAmount, float speed)
    {
        float startFillAmount = healthBarFill.fillAmount;
        float timeElapsed = 0f;

        while (timeElapsed < speed)
        {
            timeElapsed += Time.deltaTime;
            float lerpValue = timeElapsed / speed;
            healthBarFill.fillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, lerpValue);
            yield return null;
        }

        healthBarFill.fillAmount = targetFillAmount;
    }
    #endregion

    #region SWIPE DELAY

    private IEnumerator EnableSwipeAfterDelay()
    {
        yield return new WaitForSeconds(.25f);
        swipeEnabled = true;
    }

    #endregion

    #region GAME OVER

    private void GameOver()
    {
        Time.timeScale = 0;
        gameManager.GetAnimator.SetTrigger("ActiveGameOver");
        swipeEnabled = false;
    }

    #endregion
}
