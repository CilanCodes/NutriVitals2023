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

        MAX_ENTRIES = 10;

        FOODS[0, 0, 0] = "BUTTER";
        FOODS[0, 0, 1] = "CASSAVA";
        FOODS[0, 0, 2] = "CEREAL";

        FOODS[0, 1, 0] = "It's rich in nutrients like bone-building calcium and contains compounds linked to lower chances of obesity.";
        FOODS[0, 1, 1] = "High in vitamin C, an important vitamin that acts as an antioxidant.";
        FOODS[0, 1, 2] = "Have enhanced micronutrients intakes in particular, B vitamins, folate, calcium, iron, magnesium, and zinc.";

        FOODS[1, 0, 0] = "BEEF";
        FOODS[1, 0, 1] = "CRAB";
        FOODS[1, 0, 2] = "LEGUMES";

        FOODS[1, 1, 0] = "Improve muscle growth and maintenance, as well as exercise performance.";
        FOODS[1, 1, 1] = "Contains high levels of omega-3 fatty acids, vitamin B12, and selenium.";
        FOODS[1, 1, 2] = "Contains antioxidants that help prevent cell damage and fight disease and aging.";

        FOODS[2, 0, 0] = "BROCCOLI";
        FOODS[2, 0, 1] = "CABBAGE";
        FOODS[2, 0, 2] = "CARROT";

        FOODS[2, 1, 0] = "Reducing the risk of cancer.";
        FOODS[2, 1, 1] = "Packed with phytosterols (plant sterols) and insoluble fiber.";
        FOODS[2, 1, 2] = "Good source of beta carotene, fiber, vitamin K1, potassium, and antioxidants.";

        FOODS[3, 0, 0] = "CAKES";
        FOODS[3, 0, 1] = "CANDY";
        FOODS[3, 0, 2] = "COTTON CANDY";

        FOODS[3, 1, 0] = "Low in nutrition and contains a high amount of saturated fat and sugar.";
        FOODS[3, 1, 1] = "Natural antidepressants and can help stimulate your mood.";
        FOODS[3, 1, 2] = "An can cause obesity and tooth decay, which increases when sweets are stuck on teeth.";

        FOODS[4, 0, 0] = "BURGER";
        FOODS[4, 0, 1] = "FRENCH FRIES";
        FOODS[4, 0, 2] = "HOT DOG";

        FOODS[4, 1, 0] = "Rich in calories, the leading cause of gaining weight.";
        FOODS[4, 1, 1] = "Produce lower blood glucose and insulin levels in children.";
        FOODS[4, 1, 2] = "Ome from fat, and much of it is the unhealthy saturated type, increased risk of heart disease and colon cancer.";

        FOODS[5, 0, 0] = "CHIPS";
        FOODS[5, 0, 1] = "POPCORN";
        FOODS[5, 0, 2] = "WAFFLES";
        
        FOODS[5, 1, 0] = "May negatively impact your cardiovascular health, which can lead to stroke, heart failure, coronary heart disease and kidney disease.";
        FOODS[5, 1, 1] = "...";
        FOODS[5, 1, 2] = "...";

    }

    public static List<int> LEADERBOARDS { get; private set; }

    public static string[] STORY_TEXT { get; private set; }

    public static string[] ADVICE_TEXT { get; private set; }

    public static int MAX_ENTRIES { get; private set; }

    public static string[,,] FOODS { get; private set; }

}
