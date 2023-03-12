using System.Collections.Generic;
using UnityEngine;

public class ENV : MonoBehaviour
{

    void Awake()
    {

        LEADERBOARDS = new List<int> 
        {

            200, 
            175, 
            150, 
            125, 
            95,
            70,
            60, 
            50,
            40, 
            30,

        };

        STORY_TEXT = new string[]
        {

            "I WILL HELP YOU UNDERSTAND\nTHAT PROPER NUTRITION\nIS AS IMPORTANT AS PHYSICAL TRAINING",

            "YOUR TRAINING GROUND\nWILL BE FILLED WITH\nHEALTHY FOODS AND TEMPTING JUNK FOODS",

            "ALONG THE WAY,\nYOU MUST CHOOSE THE\nRIGHT FOODS  TO\nFUEL YOUR BODY AND\nIMPROVE YOUR PERFORMANCE",

            "GOODLUCK MY DEAR TRAINEE\nI WILL BE HERE WITH YOU\nALONG THE WAY",

        };

        ADVICE_TEXT = new string[]
        {
                
            "Measure and Watch Your Weight",

            "Limit Unhealthy Foods and Eat Healthy Meals",

            "Take Multivitamin Supplements",

            "Drink Water and Stay Hydrated, and Limit Sugared Beverages",

            "Exercise Regularly and Be Physically Active",

            "Reduce Sitting and Screen Time",

            "Get Enough Good Sleep",

            "Go Easy on Alcohol and Stay Sober",

            "Find Ways to Manage Your Emotions",

            "Use an App to Keep Track of Your Movement, Sleep, and Heart Rate",

        };

    }

    public static List<int> LEADERBOARDS { get; private set; }

    public static string[] STORY_TEXT { get; private set; }

    public static string[] ADVICE_TEXT { get; private set; }

}
