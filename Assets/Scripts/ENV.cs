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
        FOODS[0, 0, 3] = "CORN";
        FOODS[0, 0, 4] = "CRACKERS";
        FOODS[0, 0, 5] = "HONEY";
        FOODS[0, 0, 6] = "NOODLES";
        FOODS[0, 0, 7] = "PASTA";
        FOODS[0, 0, 8] = "POTATOES";
        FOODS[0, 0, 9] = "PURPLE YAM";

        FOODS[0, 1, 0] = "It's rich in nutrients like bone-building calcium and contains compounds linked to lower chances of obesity.";
        FOODS[0, 1, 1] = "High in vitamin C, an important vitamin that acts as an antioxidant.";
        FOODS[0, 1, 2] = "Have enhanced micronutrients intakes in particular, B vitamins, folate, calcium, iron, magnesium, and zinc.";
        FOODS[0, 1, 3] = "Rich in vitamin C, an antioxidant that helps protect your cells from damage.";
        FOODS[0, 1, 4] = "Provide beneficial protein, a nutrient required to maintain healthy tissue.";
        FOODS[0, 1, 5] = "Better for blood sugar levels than regular sugar.";
        FOODS[0, 1, 6] = "Rich in essential nutrients like iron, vitamin B, phosphorus, Magnesium and fiber.";
        FOODS[0, 1, 7] = "Pasta is made from grain, one of the basic food groups in a healthy diet that also can include vegetables, fruits, fish, and poultry.";
        FOODS[0, 1, 8] = "Rich in vitamin C, which is an antioxidant.";
        FOODS[0, 1, 9] = "Great source of anthocyanins and vitamin C, both of which are powerful antioxidants.";

        FOODS[1, 0, 0] = "BEEF";
        FOODS[1, 0, 1] = "CRAB";
        FOODS[1, 0, 2] = "LEGUMES";
        FOODS[1, 0, 3] = "MILK";
        FOODS[1, 0, 4] = "MILKFISH";
        FOODS[1, 0, 5] = "MUNGBEANS";
        FOODS[1, 0, 6] = "PEANUT BUTTER";
        FOODS[1, 0, 7] = "PEANUTS";
        FOODS[1, 0, 8] = "PORK";
        FOODS[1, 0, 9] = "SARDINES";

        FOODS[1, 1, 0] = "Improve muscle growth and maintenance, as well as exercise performance.";
        FOODS[1, 1, 1] = "Contains high levels of omega-3 fatty acids, vitamin B12, and selenium.";
        FOODS[1, 1, 2] = "Contains antioxidants that help prevent cell damage and fight disease and aging.";
        FOODS[1, 1, 3] = "Great Source of Calcium which uilds healthy bones and teeth.";
        FOODS[1, 1, 4] = "Rich in mineral content in the form of potassium, calcium, magnesium and sodium.";
        FOODS[1, 1, 5] = "Provides protein, fiber, folate, iron, potassium and magnesium.";
        FOODS[1, 1, 6] = "Loaded with so many good, health-promoting nutrients, including vitamin E, magnesium, iron, selenium and vitamin B6.";
        FOODS[1, 1, 7] = "Rich in protein, fat, and fiber.";
        FOODS[1, 1, 8] = "Full of vitamins: In particular, pork is rich in thiamine, which is a B vitamin that helps your body function properly.";
        FOODS[1, 1, 9] = "Excellent source of vitamin B-12.";

        FOODS[2, 0, 0] = "BROCCOLI";
        FOODS[2, 0, 1] = "CABBAGE";
        FOODS[2, 0, 2] = "CARROT";
        FOODS[2, 0, 3] = "CHOCOLATE";
        FOODS[2, 0, 4] = "CLAMS";
        FOODS[2, 0, 5] = "COCONUT";
        FOODS[2, 0, 6] = "EGGPLANT";
        FOODS[2, 0, 7] = "LOBSTER";
        FOODS[2, 0, 8] = "MANGO";
        FOODS[2, 0, 9] = "MORINGA LEAVES";

        FOODS[2, 1, 0] = "Reducing the risk of cancer.";
        FOODS[2, 1, 1] = "Packed with phytosterols (plant sterols) and insoluble fiber.";
        FOODS[2, 1, 2] = "Good source of beta carotene, fiber, vitamin K1, potassium, and antioxidants.";
        FOODS[2, 1, 3] = "Lower bad cholesterol levels and prevent plaque on artery walls.";
        FOODS[2, 1, 4] = "One of the greatest sources of vitamin B12 in the diet.";
        FOODS[2, 1, 5] = "Rich in fiber and MCTs.";
        FOODS[2, 1, 6] = "Has antioxidants like vitamins A and C, which help protect your cells against damage.";
        FOODS[2, 1, 7] = "Rich in protein, omega-3 fatty acids, vitamins, and minerals.";
        FOODS[2, 1, 8] = "Rich source of vitamins A, C, and D.";
        FOODS[2, 1, 9] = "Rich in vitamins A, C, B1 (thiamin), B2 (riboflavin), B3 (niacin), B6 and Folate.";

        FOODS[3, 0, 0] = "BURGER";
        FOODS[3, 0, 1] = "CAKES";
        FOODS[3, 0, 2] = "CANDY";
        FOODS[3, 0, 3] = "CHIPS";
        FOODS[3, 0, 4] = "COTTON CANDY";
        FOODS[3, 0, 5] = "DONUTS";
        FOODS[3, 0, 6] = "FRENCH FRIES";
        FOODS[3, 0, 7] = "HOT DOG";
        FOODS[3, 0, 8] = "ICE CREAM";
        FOODS[3, 0, 9] = "MILKSHAKE";

        FOODS[3, 1, 0] = "Rich in calories, the leading cause of gaining weight.";
        FOODS[3, 1, 1] = "Low in nutrition and contains a high amount of saturated fat and sugar.";
        FOODS[3, 1, 2] = "Natural antidepressants and can help stimulate your mood.";
        FOODS[3, 1, 3] = "May negatively impact your cardiovascular health, which can lead to stroke, heart failure, coronary heart disease and kidney disease.";
        FOODS[3, 1, 4] = "An can cause obesity and tooth decay, which increases when sweets are stuck on teeth.";
        FOODS[3, 1, 5] = "Have too much sugar and it can affect your body lead to obesity, diabetes, heart disease, insulin resistance and metabolic problem.";
        FOODS[3, 1, 6] = "Produce lower blood glucose and insulin levels in children.";
        FOODS[3, 1, 7] = "Ome from fat, and much of it is the unhealthy saturated type, increased risk of heart disease and colon cancer.";
        FOODS[3, 1, 8] = "Too much saturated fat and sugar, increasing risk of coronary heart disease and diabetes.";
        FOODS[3, 1, 9] = "Contain fruit, which is a good source of vitamins and dietary fiber for better digestion.";

    }

    public static List<int> LEADERBOARDS { get; private set; }

    public static string[] STORY_TEXT { get; private set; }

    public static string[] ADVICE_TEXT { get; private set; }

    public static int MAX_ENTRIES { get; private set; }

    public static string[,,] FOODS { get; private set; }

}
