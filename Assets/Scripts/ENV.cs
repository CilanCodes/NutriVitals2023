using System.Collections.Generic;
using UnityEngine;

public class ENV : MonoBehaviour
{

    void Awake()
    {

        FOODS = new string[6, 2, 9]
        {

            { { "", "", "", "", "", "", "", "", "", }, { "", "", "", "", "", "", "", "", "", }, },
            { { "", "", "", "", "", "", "", "", "", }, { "", "", "", "", "", "", "", "", "", }, },
            { { "", "", "", "", "", "", "", "", "", }, { "", "", "", "", "", "", "", "", "", }, },
            { { "", "", "", "", "", "", "", "", "", }, { "", "", "", "", "", "", "", "", "", }, },
            { { "", "", "", "", "", "", "", "", "", }, { "", "", "", "", "", "", "", "", "", }, },
            { { "", "", "", "", "", "", "", "", "", }, { "", "", "", "", "", "", "", "", "", }, },

        };

        LEADERBOARDS = new List<LeaderboardModel>
        {

            new LeaderboardModel(200, "Coach"),
            new LeaderboardModel(175, "Rexie"),
            new LeaderboardModel(150, "Denver"),
            new LeaderboardModel(125, "Miles"),
            new LeaderboardModel(95, "Gabriel"),
            new LeaderboardModel(70, "Dianne"),
            new LeaderboardModel(60, "Rhocel"),
            new LeaderboardModel(50, "Christian"),
            new LeaderboardModel(40, "Angel"),
            new LeaderboardModel(30, "Cilan"),

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

            "Go foods give you energy and fuel for maintaining a healthy brain",
            "Go Foods are Carbohydrates that provide quick energy for physical activity",

            "Grow foods develops the body , becomes stronger, and becomes healthier",
            "Grow Foods are Protein that builds and repairs tissues",

            "Glow foods help the immune system become stronger",
            "Glow Foods provide vitamins and minerals that promote healthy skin",

            "Frozen or prepared meals are often the most highly processed foods",

            "Too much added sugar in food and beverages can lead to health issues like weight gain",

            "Eating high amounts of saturated fat can increase LDL or bad cholesterol",

            "Being in a low energy state might result in hunger, anxiety, and even small sleep problems",

            "Overeating can increase blood pressure and cholesterol, causing discomfort",

            "Superfoods or Nutrient-dense are foods that is combination of go, grow, and glow",
            "Berries are superfoods they contain antioxidants, fiber (Go, Glow), protein, vitamins, minerals (Grow)",
            "Sweet potatoes are superfoods they  contain Carbs, fiber, and vitamins (Go, Glow), vitamin A (Grow).",

        };

        MAX_ENTRIES = 10;

        //GO FOODS HERE
        FOODS[0, 0, 0] = "POTATOES";
        FOODS[0, 0, 1] = "HONEY";
        FOODS[0, 0, 2] = "CORN";
        FOODS[0, 0, 3] = "BREAD";
        FOODS[0, 0, 4] = "RICE";
        FOODS[0, 0, 5] = "CEREAL";
        FOODS[0, 0, 6] = "BUTTER";
        FOODS[0, 0, 7] = "CRACKERS";
        FOODS[0, 0, 8] = "CASSAVA";


        FOODS[0, 1, 0] = "Energy, fiber, vitamin C, and potassium for strong bones, teeth, and muscles.";
        FOODS[0, 1, 1] = "Natural sugar, antioxidants, antibacterial properties, soothes coughs and sore throats, and promotes healing.";
        FOODS[0, 1, 2] = "Fiber, antioxidants, essential nutrients, improves digestion, healthy eyesight, skin, and immune system.";
        FOODS[0, 1, 3] = "Carbohydrates, fiber, vitamins, minerals, energy, and supports healthy digestion.";
        FOODS[0, 1, 4] = "Carbohydrates, fiber, vitamins, minerals, energy, and supports healthy brain function.";
        FOODS[0, 1, 5] = "Fiber, vitamins, minerals, energy, supports healthy digestion, and can reduce the risk of heart disease.";
        FOODS[0, 1, 6] = "Healthy fats, vitamins, minerals, and supports brain function and heart health.";
        FOODS[0, 1, 7] = "Carbohydrates, fiber, energy, and supports healthy digestion.";
        FOODS[0, 1, 8] = "Carbohydrates, fiber, vitamins, minerals, energy, and supports healthy digestion.";

        //GROW FOODS HERE
        FOODS[1, 0, 0] = "PEANUT";
        FOODS[1, 0, 1] = "MILK";
        FOODS[1, 0, 2] = "LEGUMES";
        FOODS[1, 0, 3] = "TUNA";
        FOODS[1, 0, 4] = "SHRIMP";
        FOODS[1, 0, 5] = "CRAB";
        FOODS[1, 0, 6] = "PORK";
        FOODS[1, 0, 7] = "BEEF";
        FOODS[1, 0, 8] = "EGG";

        FOODS[1, 1, 0] = "Protein, healthy fats, fiber, strong muscles, healthy weight, and reduces the risk of heart disease.";
        FOODS[1, 1, 1] = "Calcium, protein, vitamin D, strong bones, teeth, healthy skin, and supports nerve function.";
        FOODS[1, 1, 2] = "Protein, fiber, vitamins, minerals, regulate blood sugar, and promote heart health.";
        FOODS[1, 1, 3] = "Protein, healthy fats, vitamins, minerals, and promotes heart health.";
        FOODS[1, 1, 4] = "Protein, omega-3 fatty acids, minerals, and supports brain function and heart health.";
        FOODS[1, 1, 5] = "Protein, vitamins, minerals, and supports bone health and immune system function.";
        FOODS[1, 1, 6] = "Protein, vitamins, minerals, and supports muscle growth and immune system function.";
        FOODS[1, 1, 7] = "Protein, iron, vitamins, minerals, and supports muscle growth and bone health.";
        FOODS[1, 1, 8] = "Protein, healthy fats, vitamins, minerals, and supports muscle growth and brain function.";

        //GLOW FOODS HERE
        FOODS[2, 0, 0] = "APPLE";
        FOODS[2, 0, 1] = "MANGO";
        FOODS[2, 0, 2] = "EGGPLANT";
        FOODS[2, 0, 3] = "COCONUT";
        FOODS[2, 0, 4] = "WATERMELON";
        FOODS[2, 0, 5] = "SPINACH";
        FOODS[2, 0, 6] = "TOMATO";
        FOODS[2, 0, 7] = "ORANGE";
        FOODS[2, 0, 8] = "BROCOLLI";

        FOODS[2, 1, 0] = "Fiber, vitamin C; aids digestion, boosts immunity, may lower risk of chronic diseases.";
        FOODS[2, 1, 1] = "Vitamin C, antioxidants, fiber, promotes healthy skin, eyesight, digestion, and immune system.";
        FOODS[2, 1, 2] = "Fiber, antioxidants, vitamins, minerals, promotes healthy digestion, brain function, and lowers cholesterol.";
        FOODS[2, 1, 3] = "Fiber, healthy fats, vitamins, minerals, and supports heart health and healthy skin.c";
        FOODS[2, 1, 4] = "Vitamins, antioxidants, water, promotes hydration, healthy skin, and boosts the immune system.";
        FOODS[2, 1, 5] = "Vitamins, minerals, fiber, promotes healthy digestion, bone health, and lowers the risk of heart disease.";
        FOODS[2, 1, 6] = "Contains vitamin C and lycopene, good for eyes and skin health.";
        FOODS[2, 1, 7] = "High in vitamin C, strengthens immune system and improves digestion.";
        FOODS[2, 1, 8] = "Contains vitamin C, fiber, and calcium, promotes strong bones and teeth.";

        //SUGARY FOODS HERE
        FOODS[3, 0, 0] = "CAKE";
        FOODS[3, 0, 1] = "SODA";
        FOODS[3, 0, 2] = "ICE CREAM";

        FOODS[3, 1, 0] = "High in sugar and calories, can lead to weight gain and tooth decay.";
        FOODS[3, 1, 1] = "High in sugar, can lead to obesity, type 2 diabetes, and tooth decay.";
        FOODS[3, 1, 2] = "High in sugar and fat, can lead to weight gain and high cholesterol.";

        //FATTY FOODS HERE
        FOODS[4, 0, 0] = "FRIES";
        FOODS[4, 0, 1] = "PIZZA";
        FOODS[4, 0, 2] = "HOTDOG";

        FOODS[4, 1, 0] = "High in fat and salt, can lead to weight gain and high blood pressure.";
        FOODS[4, 1, 1] = "High in calories, fat, and salt, can lead to weight gain and heart disease.";
        FOODS[4, 1, 2] = "Processed meat, can lead to increased risk of cancer and heart disease.";

        //PROCESSED FOODS HERE
        FOODS[5, 0, 0] = "CANNED FOODS";
        FOODS[5, 0, 1] = "CHIPS";
        FOODS[5, 0, 2] = "NOODLES";

        FOODS[5, 1, 0] = "High in preservatives and sodium, can lead to high blood pressure and kidney damage.";
        FOODS[5, 1, 1] = "High in fat and salt, can lead to weight gain and high blood pressure.";
        FOODS[5, 1, 2] = "High in sodium and processed ingredients, can lead to obesity and heart disease.";

        GAME_OVER = "gameOver";
        PAUSED = "pause";
        ON_OVERLAY_STATUS = "onOverlayStatus";
        OFF_OVERLAY_STATUS = "offOverlayStatus";
        CLOSE = "close";

    }

    public static List<LeaderboardModel> LEADERBOARDS { get; private set; }

    public static string[] STORY_TEXT { get; private set; }

    public static string[] ADVICE_TEXT { get; private set; }

    public static int MAX_ENTRIES { get; private set; }

    public static string[,,] FOODS { get; private set; }

    public static string GAME_OVER { get; private set; }

    public static string PAUSED { get; private set; }

    public static string ON_OVERLAY_STATUS { get; private set; }

    public static string OFF_OVERLAY_STATUS { get; private set; }

    public static string CLOSE { get; private set; }


}
