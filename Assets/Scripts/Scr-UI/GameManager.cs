using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject healthyScrollView;
    [SerializeField] private GameObject junkScrollView;
    [SerializeField] private TextMeshProUGUI points;

    [SerializeField] private ScrollRect aboutScrollView;
    [SerializeField] private ScrollRect leaderboardScrollView;

    //private float timeLeft = 25.0f; // 5 minutes in seconds

    public Animator GetAnimator
    {

        get { return animator; }

    }


    void Start()
    {

        PlayerPrefs.SetInt("index", 2);

    }

    private void Update()
    {

        #region BUTTON GUIDES
        //Update your ProjectSettings>Player>OtherSettings>ActiveInputHandling>Both
        //SimpleInput.GetButton <-- Holding a Button
        //SimpleInput.GetButtonDown <-- Upon Pressing, execute
        //SimpleInput.GetButtonUp <-- Upon Release, execute
        #endregion

        if (SimpleInput.GetButtonDown("OnRunNowGameScreen"))

            LoadScene(4);

        if (SimpleInput.GetButtonDown("OnFoodInformationScreen"))

            //no need to call PlayerPrefs because your 
            SceneManager.LoadScene(3);

        if (SimpleInput.GetButtonDown("OnHomeScreen"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        if (SimpleInput.GetButtonDown("OnReturnHomeScreen"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(2);
        }

        if (SimpleInput.GetButtonDown("OnPromptSettings"))
        {
            animator.SetTrigger("ActiveSettings");
        }

        if (SimpleInput.GetButtonDown("OnPromptAbout"))
        {
            aboutScrollView.verticalNormalizedPosition = 1f;
            animator.SetTrigger("ActiveAbout");
        }

        if (SimpleInput.GetButtonDown("OnPromptLeaderboard"))
        {
            leaderboardScrollView.verticalNormalizedPosition = 1f;
            animator.SetTrigger("ActiveLeaderboard");
        }

        if (SimpleInput.GetButtonDown("OnPromptDisable"))
        {
            //PauseUnpauseTime(1);
            animator.SetTrigger("InActivate");
            //Debug.Log("Hide Paused");
            Time.timeScale = 1;
            HUDManager.swipeEnabled = true;

        }

        if (SimpleInput.GetButtonDown("OnSkipStory"))

            LoadScene(2);

        if (SimpleInput.GetButtonDown("OnPromptPaused"))
        {
            //Debug.Log("Paused");
            animator.SetTrigger("InActivateOverlayStatus");
            animator.SetTrigger("ActivePause");
            Time.timeScale = 0;
            HUDManager.swipeEnabled = false;
        }

        if (SimpleInput.GetButtonDown("OnPlayAgain"))
        {
            SceneManager.LoadScene("GameScreen");
            Time.timeScale = 1;
            //Debug.Log(PlayerController.targetPosition.z);
            FoodManager.isReplayAgain = true;

        }

    }

    private void LoadScene(int _index)
    {

        PlayerPrefs.SetInt("index", _index);
        SceneManager.LoadScene(0);

    }

    public void OnLoadScene(int _index) => LoadScene(_index);

}
