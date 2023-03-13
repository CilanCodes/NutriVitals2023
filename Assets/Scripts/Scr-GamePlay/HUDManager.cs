using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public static int scorePoints;
    public static float energyPoints;
    public static float healthPoints;
    public static int goPoints;
    public static int growPoints;
    public static int glowPoints;
    public static bool swipeEnabled;
    public static bool isScoreAdded;

    [SerializeField] 
    private Image energyBarFill;

    [SerializeField] 
    public Image healthBarFill;

    [SerializeField] 
    private TextMeshProUGUI scoreTextPoints;

    [SerializeField] 
    private TextMeshProUGUI gameOverTextPoints;

    [SerializeField] 
    private TextMeshProUGUI goTextPoints;

    [SerializeField] 
    private TextMeshProUGUI growTextPoints;

    [SerializeField] 
    private TextMeshProUGUI glowTextPoints;

    [SerializeField] 
    private GameObject gameOverPanel;

    [SerializeField] 
    private float decreaseSpeed = 2f;

    [SerializeField] 
    private const float decreaseInterval = 4f;

    private float timeSinceLastDecrease = 0f;

    private void Start()
    {

        ResetAllPoints();
        StartCoroutine(EnableSwipeAfterDelay());

        //scorePoints = 1450;// this for testing maps : RESET THIS BACK TO 0 BEFORE DEPLOY

        FindObjectOfType<GameManager>().OnTrigger("offOverlayStatus");

        FoodManager.isReplayAgain = true;
        isScoreAdded = false;

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


        if (StateManager.PowerUpTypeState == StateManager.POWER_UP_TYPE.GO)
        {
            goTextPoints.text = "5";
            growTextPoints.text = growPoints.ToString();
            glowTextPoints.text = glowPoints.ToString();
        }
        else if (StateManager.PowerUpTypeState == StateManager.POWER_UP_TYPE.GROW)
        {
            goTextPoints.text = goPoints.ToString(); ;
            growTextPoints.text = "5";
            glowTextPoints.text = glowPoints.ToString();
        }
        else if (StateManager.PowerUpTypeState == StateManager.POWER_UP_TYPE.GLOW)
        {
            goTextPoints.text = goPoints.ToString();
            growTextPoints.text = growPoints.ToString();
            glowTextPoints.text = "5";
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

        if ((0 <= energyBarFill.fillAmount && energyBarFill.fillAmount <= .17) || (.835 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 1))
        {
            DecreaseHealthBar();
            FindObjectOfType<GameManager>().OnTrigger(ENV.ON_OVERLAY_STATUS);

            //LOW ENERGY LEVEL
            if (0 <= energyBarFill.fillAmount && energyBarFill.fillAmount <= .17)
            {
                StateManager.EnergyState = StateManager.ENERGY.LOW_DANGER;
                PlayerController.swipeSensitivity = 150f;
                PlayerController.forwardSpeed = 80;
                CharacterAnimationController.animationRunSpeed = 0.4f;
            }

            //HIGH ENERGY LEVEL
            if (.835 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 1)
            {
                StateManager.EnergyState = StateManager.ENERGY.HIGH_DANGER;
                PlayerController.swipeSensitivity = 0.5f;
                PlayerController.forwardSpeed = 300;
                CharacterAnimationController.animationRunSpeed = 2f;
            }

        }

        #endregion

        #region HEALTHY / WARNING LEVELS
        else
        {
            if (StateManager.PowerUpState == StateManager.POWER_UP.POWER_UP)
            {
                FindObjectOfType<GameManager>().OnTrigger(ENV.ON_OVERLAY_STATUS);
            }
            else
            {
                FindObjectOfType<GameManager>().OnTrigger(ENV.OFF_OVERLAY_STATUS);

            }

            //WARNING / YELLOW ENERGY LEVEL
            if ((0.17 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 0.37) || (0.635 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 0.835))
            {
                FindObjectOfType<GameManager>().OnTrigger(ENV.OFF_OVERLAY_STATUS);

                //LOW LEVEL WARNING
                if (0.17 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 0.37)
                {
                    StateManager.EnergyState = StateManager.ENERGY.LOW_WARNING;
                    PlayerController.forwardSpeed = 130;
                    CharacterAnimationController.animationRunSpeed = 0.7f;
                }
                //HIGH LEVEL WARNING
                if (0.635 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 0.835)
                {
                    StateManager.EnergyState = StateManager.ENERGY.HIGH_WARNING;
                    PlayerController.forwardSpeed = 170;
                    CharacterAnimationController.animationRunSpeed = 1.5f;
                }


            }

            //HEALTHY / GREEN ENERGY LEVEL
            if (0.37 < energyBarFill.fillAmount && energyBarFill.fillAmount <= 0.635)
            {
                StateManager.EnergyState = StateManager.ENERGY.BALANCED;
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
        FindObjectOfType<GameManager>().OnTrigger(ENV.ON_OVERLAY_STATUS);

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
        FindObjectOfType<GameManager>().OnTrigger(ENV.GAME_OVER);
        swipeEnabled = false;

        if (isScoreAdded)
        {
            return;
        }

        int newScore = scorePoints;

        FindObjectOfType<User>().LeaderboardScores.Add(newScore);
        FindObjectOfType<User>().OnSave();

        //leaderboardManager.AddCurrentScoreToLeaderboard();
        isScoreAdded = true;
    }

    #endregion
}
