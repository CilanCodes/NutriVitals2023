using UnityEngine.SceneManagement;
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

    public Button homeButton;
    public Button retryButton;
    public Button retryButton2;

    public static bool gameOver;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
        goCount = 0;
        growCount = 0;
        glowCount = 0;

        gameOver = false;

        Time.timeScale = 1;

        homeButton.onClick.AddListener(HomeButtonClicked);
        retryButton.onClick.AddListener(RetryButtonClicked);
        retryButton2.onClick.AddListener(RetryButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        gameScore += 1 * Time.deltaTime;
        scoreText.text = "" + Mathf.Round (gameScore);
        goCountText.text = Mathf.Round (goCount) + "";
        growCountText.text = Mathf.Round (growCount) + "";
        glowCountText.text = Mathf.Round (glowCount) + "";
        if(goCount == 5 || growCount == 5 || glowCount == 5){
            goCount = 0;
            growCount = 0;
            glowCount = 0;
        }
        speedPercentage.text = Mathf.Round (speed) + "%";

        if (gameOver){
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        if (gameScore <= 0){
            gameScore = 0;
        }
    }

    void HomeButtonClicked(){
        SceneManager.LoadScene("HomeScreen");
    }

    void RetryButtonClicked(){
        SceneManager.LoadScene("GameScreen");
    }

}
