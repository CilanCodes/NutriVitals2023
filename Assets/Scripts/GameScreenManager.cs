using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class GameScreenManager : MonoBehaviour
{

    [Header("MAIN SECTION")]
    [SerializeField] 
    private GameObject countdownHUD;

    [SerializeField] 
    private TextMeshProUGUI adviceUIText;

    [SerializeField]
    private TextMeshProUGUI countdownUIText;

    [SerializeField]
    private Image goalImage;

    [SerializeField]
    private Sprite[] rewardGoalsSprites;

    public static int hasReachedScore;

    [SerializeField]
    private Image coachGuideImage;

    [SerializeField]
    private Sprite[] coachGuideSprites;

    public static bool guideIsPlaying;

    void Start()
    {
        FoodManager.isReplayAgain = true;
        PlayerPrefs.SetInt("index", 2);
        int countdown = 3;
        StartCoroutine(CountdownToStart(countdown));


        hasReachedScore = PlayerPrefs.GetInt("_hasReachedScore", 0);

        if (hasReachedScore == 0)
        
            StartCoroutine(StartingGoal(rewardGoalsSprites[0]));

        else if (hasReachedScore == 1500)

            StartCoroutine(StartingGoal(rewardGoalsSprites[1]));

        else if (hasReachedScore == 3000)

            StartCoroutine(StartingGoal(rewardGoalsSprites[2]));

        else if (hasReachedScore == 4500)

            StartCoroutine(StartingGoal(rewardGoalsSprites[3]));


        //FOR TESTING REMOVALS
        PlayerPrefs.SetInt("_guideGoPower", 0);
        PlayerPrefs.SetInt("_guideGrowPower", 0);
        PlayerPrefs.SetInt("_guideGlowPower", 0);
        PlayerPrefs.SetInt("_guideHighEnergy", 0);
        PlayerPrefs.SetInt("_guideLowerEnergy", 0);
        PlayerPrefs.SetInt("_guideJunkFood", 0);
        PlayerPrefs.SetInt("_hasPlayed", 0);
        //REMOVE THIS AFTERWARDS

    }

    void Update()
    {

        if (SimpleInput.GetButtonDown("OnRestart"))
        {

            GameManager.OnLoadScene(4);
            Time.timeScale = 1;
            FoodManager.isReplayAgain = true;

        }

        if (SimpleInput.GetButtonDown("OnReturnHome"))
        {

            GameManager.OnLoadScene(2);
            Time.timeScale = 1;
            FoodManager.isReplayAgain = true;

        }

        if (SimpleInput.GetButtonDown("OnPaused"))
        {

            FindObjectOfType<GameManager>().OnTrigger(ENV.OFF_OVERLAY_STATUS);
            FindObjectOfType<GameManager>().OnTrigger(ENV.PAUSED);
            StateManager.IsMoving = false;
            Time.timeScale = 0;
            Advice();

        }

        if (SimpleInput.GetButtonDown("OnClose1"))
        {
            StateManager.IsMoving = true;
            Time.timeScale = 1;
            int countdown = 3;
            StartCoroutine(CountdownToStart(countdown));

        }

    }

    private void Advice()
    {

        int random = Random.Range(0, ENV.ADVICE_TEXT.Length);
        string randomAdvice = ENV.ADVICE_TEXT[random];
        adviceUIText.text = randomAdvice;

    }

    private IEnumerator CountdownToStart(int _countdown)
    {

        countdownHUD.SetActive(true);
        StateManager.IsMoving = false;

        while (_countdown > 0)
        {

            countdownUIText.text = _countdown.ToString();

            yield return new WaitForSeconds(1f);

            _countdown--;

        }

        StateManager.IsMoving = true;
        countdownHUD.SetActive(false);

    }

    public void GetAdvice() => Advice();

    private IEnumerator CoachGuide(Sprite _guideSprite)
    {
        //GameObject.Find("CoachGuide").GetComponent<Animator>().SetTrigger("offGuide");
        guideIsPlaying = true;

        coachGuideImage.sprite = _guideSprite;

        yield return new WaitForSeconds(0.1f);

        GameObject.Find("CoachGuide").GetComponent<Animator>().SetTrigger("onGuide");

        yield return new WaitForSeconds(8f);

        GameObject.Find("CoachGuide").GetComponent<Animator>().SetTrigger("offGuide");

        guideIsPlaying = false;
    }

    private void ActivateCoachGuide(int _guideIndex)
    {
        StartCoroutine(CoachGuide(coachGuideSprites[_guideIndex]));
    }



    private IEnumerator StartingGoal(Sprite _itemSprite)
    {
        goalImage.sprite = _itemSprite;

        yield return new WaitForSeconds(5f);

        GameObject.Find("BannerReward").GetComponent<Animator>().SetTrigger("onGoal");

        yield return new WaitForSeconds(8f);

        GameObject.Find("BannerReward").GetComponent<Animator>().SetTrigger("offGoal");


    }

    private IEnumerator GoalReached(Sprite _itemSprite)
    {
        goalImage.sprite = _itemSprite;

        

        GameObject.Find("BannerReward").GetComponent<Animator>().SetTrigger("onGoal");

        yield return new WaitForSeconds(8f);

        GameObject.Find("BannerReward").GetComponent<Animator>().SetTrigger("offGoal");

        yield return new WaitForSeconds(2f);

        //FOR TESTING
        if (PlayerPrefs.GetInt("_hasReachedScore", 0) == 1500
            && PlayerPrefs.GetInt("_hasPlayed", 0) == 0)
        {
            StartCoroutine(GoalReached(rewardGoalsSprites[1]));
            PlayerPrefs.SetInt("_hasPlayed", 1);
        }
            
        else if (PlayerPrefs.GetInt("_hasReachedScore", 0) == 3000
            && PlayerPrefs.GetInt("_hasPlayed", 0) == 1)
        {
            StartCoroutine(GoalReached(rewardGoalsSprites[2]));
            PlayerPrefs.SetInt("_hasPlayed", 2);
        }
            

        else if (PlayerPrefs.GetInt("_hasReachedScore", 0) == 4500
               && PlayerPrefs.GetInt("_hasPlayed", 0) == 2)
        {
            StartCoroutine(GoalReached(rewardGoalsSprites[3]));
            PlayerPrefs.SetInt("_hasPlayed", 3);
        }



        //DELETE IF NOT WORKING

    }

    private void RewardObtained(int _rewardIndex)
    {
        StartCoroutine(GoalReached(rewardGoalsSprites[_rewardIndex]));
    }

    public void RewardObtainedShoe() => RewardObtained(4);

    public void RewardObtainedCap() => RewardObtained(5);

    public void RewardObtainedBag() => RewardObtained(6);

    public void RewardObtainedOutfit() => RewardObtained(7);

    public void GuideGoPower() => ActivateCoachGuide(0);
    public void GuideGrowPower() => ActivateCoachGuide(1);
    public void GuideGlowPower() => ActivateCoachGuide(2);
    public void GuideHighEnergy() => ActivateCoachGuide(3);
    public void GuideLowEnergy() => ActivateCoachGuide(4);
    public void GuideJunkFood() => ActivateCoachGuide(5);


}
