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

    [SerializeField] private Image energyBarFill;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private TextMeshProUGUI scoreTextPoints;
    [SerializeField] private TextMeshProUGUI gameOverTextPoints;
    [SerializeField] private TextMeshProUGUI goTextPoints;
    [SerializeField] private TextMeshProUGUI growTextPoints;
    [SerializeField] private TextMeshProUGUI glowTextPoints;

    [SerializeField] private GameObject gameOverPanel;

    private float timeSinceLastDecrease = 0f;
    [SerializeField] private float decreaseSpeed = .5f;
    [SerializeField] private const float decreaseInterval = 2f;

    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        ResetAllPoints();
        StartCoroutine(EnableSwipeAfterDelay());
        Debug.Log(healthPoints);
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

        goTextPoints.text = goPoints.ToString();
        growTextPoints.text = growPoints.ToString();
        glowTextPoints.text = glowPoints.ToString();

        if ((energyBarFill.fillAmount >= 0 && energyBarFill.fillAmount <= .17) || (energyBarFill.fillAmount >= .83 && energyBarFill.fillAmount <= 1))
        {
            DecreaseHealthBar();
        }

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
            if((scorePoints+score) < 0) {
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



    //SMOOTH HEALTH BAR
    private void DecreaseHealthBar()
    {
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

    private IEnumerator EnableSwipeAfterDelay()
    {
        yield return new WaitForSeconds(.25f);
        swipeEnabled = true;
    }

    private void GameOver()
    {
        //gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        //GameManager.animator.SetTrigger("ActiveGameOver");
        gameManager.GetAnimator.SetTrigger("ActiveGameOver");
        swipeEnabled = false;
        
    }
}
