using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public Button homeButton;
    public Button retryButton;
    public Button retryButton2;
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(PauseButtonClicked);
        resumeButton.onClick.AddListener(ResumeButtonClicked);
        homeButton.onClick.AddListener(HomeButtonClicked);
        retryButton.onClick.AddListener(RetryButtonClicked);
        retryButton2.onClick.AddListener(RetryButtonClicked);
    }

    void PauseButtonClicked(){
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    void ResumeButtonClicked(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    void HomeButtonClicked(){
        SceneManager.LoadScene("HomeScreen");
    }

    void RetryButtonClicked(){
        SceneManager.LoadScene("GameScreen");
    }
}
