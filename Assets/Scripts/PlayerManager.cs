using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static float gameScore;
    public static float goCount;
    public static float growCount;
    public static float glowCount;
    public static float speed;
    public Text goCountText;
    public Text growCountText;
    public Text glowCountText;
    public Text speedPercentage;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
        goCount = 0;
        growCount = 0;
        glowCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameScore += 1 * Time.deltaTime;
        scoreText.text = "" + Mathf.Round (gameScore);
        goCountText.text = Mathf.Round (goCount) + "/5";
        growCountText.text = Mathf.Round (growCount) + "/5";
        glowCountText.text = Mathf.Round (glowCount) + "/5";
        if(goCount == 5 || growCount == 5 || glowCount == 5){
            goCount = 0;
            growCount = 0;
            glowCount = 0;
        }
        speedPercentage.text = Mathf.Round (speed) + "%";
    }

}
