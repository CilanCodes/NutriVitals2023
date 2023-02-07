using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject healthyScrollView;
    [SerializeField] private GameObject junkScrollView;

    public Animator GetAnimator
    {

        get { return animator; }

    }


    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Invoke("OpenHomeScreen", 5f);
        }

        PlayerPrefs.SetInt("index", 2);

    }

    private void OpenHomeScreen()
    {
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        //Update your ProjectSettings>Player>OtherSettings>ActiveInputHandling>Both
        //SimpleInput.GetButton <-- Holding a Button
        //SimpleInput.GetButtonDown <-- Upon Pressing, execute
        //SimpleInput.GetButtonUp <-- Upon Release, execute
        if (SimpleInput.GetButtonDown("OnRunNowGameScreen"))
        {
            PlayerPrefs.SetInt("index", 4);
            SceneManager.LoadScene(0);
        }

        if (SimpleInput.GetButtonDown("OnFoodInformationScreen"))
        {
            //no need to call PlayerPrefs because your 
            SceneManager.LoadScene(3);
        }

        if (SimpleInput.GetButtonDown("OnReturnHomeScreen"))
        {
            SceneManager.LoadScene(2);
        }

        if (SimpleInput.GetButtonDown("OnPromptSettings"))
        {
            animator.SetTrigger("ActiveSettings");
        }

        if (SimpleInput.GetButtonDown("OnPromptAbout"))
        {
            animator.SetTrigger("ActiveAbout");
        }

        if (SimpleInput.GetButtonDown("OnPromptLeaderboard"))
        {
            animator.SetTrigger("ActiveLeaderboard");
        }

        if (SimpleInput.GetButtonDown("OnPromptDisable"))
        {
            animator.SetTrigger("InActivate");
        }

        if (SimpleInput.GetButtonDown("OnPromptGameOver"))
        {
    
        }

        if (SimpleInput.GetButtonDown("OnPromptPaused"))
        {

        }

        if (SimpleInput.GetButtonDown("OnActiveHealthyScrollView"))
        {
            
        }

    }
}
