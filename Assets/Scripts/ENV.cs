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

    }

    private void DontDestroy()
    {

        if (FindObjectsOfType(GetType()).Length > 1)

            Destroy(gameObject);

        else

            DontDestroyOnLoad(gameObject);

    }

    public List<int> LEADERBOARDS { get; private set; }

}
