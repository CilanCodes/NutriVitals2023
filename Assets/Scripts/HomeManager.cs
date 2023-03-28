using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{

    [SerializeField]
    private ScrollRect aboutUIScrollRect;

    [SerializeField]
    private ScrollRect leaderboardUIScrollRect;

    [SerializeField]
    private ScrollRect achievementsUIScrollRect;

    [SerializeField]
    private GameObject[] equipButtons;

    [SerializeField]
    private GameObject[] unequipButtons;

    [SerializeField]
    private GameObject[] lockedItems;

    [SerializeField]
    private GameObject[] unlockedItems;

    private bool rewardIsEquippedShoes;
    private bool rewardIsEquippedCap;
    private bool rewardIsEquippedBag;
    private bool rewardIsEquippedShirtAndPants;

    void Start()
    {

        PlayerPrefs.SetInt("index", 2);

    }

    void Update()
    {

        if (SimpleInput.GetButtonDown("OnRunNow"))

            GameManager.OnLoadScene(4);

        if (SimpleInput.GetButtonDown("OnFoodInformation"))

            SceneManager.LoadScene(3);

        if (SimpleInput.GetButtonDown("OnSettings"))

            FindObjectOfType<GameManager>().OnTrigger("settings");

        if (SimpleInput.GetButtonDown("OnAbout"))
        {

            aboutUIScrollRect.verticalNormalizedPosition = 1f;
            FindObjectOfType<GameManager>().OnTrigger("about");

        }

        if (SimpleInput.GetButtonDown("OnLeaderboard"))
        {

            leaderboardUIScrollRect.verticalNormalizedPosition = 1f;
            FindObjectOfType<GameManager>().OnTrigger("leaderboard");

        }

        if (SimpleInput.GetButtonDown("OnAchievements"))
        {
            achievementsUIScrollRect.verticalNormalizedPosition = 1f;
            FindObjectOfType<GameManager>().OnTrigger("achievements");
        }

    }

}
