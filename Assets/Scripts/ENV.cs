using System.Collections.Generic;
using UnityEngine;

public class ENV : MonoBehaviour
{

    void Awake()
    {

        DontDestroy();

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

            "GOODLUCK MY DEAR TRAINEE\nI WILL BE HERE WITH YOU\nALONG THE WAY"

        };

    }

    private void DontDestroy()
    {

        if (FindObjectsOfType(GetType()).Length > 1)

            Destroy(gameObject);

        else

            DontDestroyOnLoad(gameObject);

    }

    public static List<int> LEADERBOARDS { get; private set; }

    public static string[] STORY_TEXT { get; private set; }

}
