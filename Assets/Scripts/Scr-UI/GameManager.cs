using System.Linq;
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

    [SerializeField] private TextMeshProUGUI coachAdvice;

    //private float timeLeft = 25.0f; // 5 minutes in seconds

    private string[] advice =
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
        "Use an App to Keep Track of Your Movement, Sleep, and Heart Rate"
    };

    public Animator GetAnimator
    {
        
        get { return animator; }

    }


    void Start()
    {

        CoachAdviceRandomizer();

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

            LoadScene(2);

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

    private static void LoadScene(int _index)
    {

        PlayerPrefs.SetInt("index", _index);
        SceneManager.LoadScene(0);

    }

    private void CoachAdviceRandomizer()
    {
        string randomAdvice = advice[Random.Range(0, advice.Length)];
        coachAdvice.text = randomAdvice;
    }

    public static void OnLoadScene(int _index) => LoadScene(_index);

    /*
     * Upon calling this method it must return a string value of current active toggle belong to the toggle group.
     */
    private string ToggleName(ToggleGroup _toggleGroup)
    {

        /*
         * Let's locally declare a TOGGLE field.
         * Also, let's initialize it's value to a PARAMETERIZED TOGGLE GROUP
         * that returns a value of current active TOGGLE belong to that TOGGLE GROUP.
         */
        Toggle toggle = _toggleGroup
            .ActiveToggles()
            .FirstOrDefault();

        // Lastly, let's returns a string value of current active toggle.
        return toggle.name.ToString();

    }

    /*
     * Let's publicly declare a GetToggle method that has a string value.
     * Also, let's add a publicly get method init.
     */
    public string GetToggleName(ToggleGroup _toggleGroup) => ToggleName(_toggleGroup);

}
