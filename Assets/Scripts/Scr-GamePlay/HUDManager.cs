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
    public static int goPoints;
    public static int growPoints;
    public static int glowPoints;

    [SerializeField] private Image energyBarFill;
    [SerializeField] private TextMeshProUGUI scoreTextPoints;
    [SerializeField] private TextMeshProUGUI goTextPoints;
    [SerializeField] private TextMeshProUGUI growTextPoints;
    [SerializeField] private TextMeshProUGUI glowTextPoints;


    private void Start()
    {
        ResetAllPoints();
    }

    private void Update()
    {

        //Prevent Update() from continuing even if the game is paused
        if (Time.timeScale == 0)
            return;

        #region UPDATE HUD ELEMENTS

        energyBarFill.fillAmount = energyPoints;
        scoreTextPoints.text = scorePoints.ToString();
        goTextPoints.text = goPoints.ToString();
        growTextPoints.text = growPoints.ToString();
        glowTextPoints.text = glowPoints.ToString();

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
        scorePoints += score;
        energyPoints += energy;
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


}
