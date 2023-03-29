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

        yield return new WaitForSeconds(0.25f);

        GameObject.Find("BannerReward").GetComponent<Animator>().SetTrigger("onGoal");

        yield return new WaitForSeconds(8f);

        GameObject.Find("BannerReward").GetComponent<Animator>().SetTrigger("offGoal");

    }

    private void RewardObtained(int _rewardIndex)
    {
        StartCoroutine(GoalReached(rewardGoalsSprites[_rewardIndex]));
    }

    public void RewardObtainedShoe() => RewardObtained(4);

    public void RewardObtainedCap() => RewardObtained(5);

    public void RewardObtainedBag() => RewardObtained(6);

    public void RewardObtainedOutfit() => RewardObtained(7);

}
