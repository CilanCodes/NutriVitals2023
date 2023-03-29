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
    private bool rewardIsEquippedOutfit;

    private bool rewardIsUnlockedShoes;
    private bool rewardIsUnlockedCap;
    private bool rewardIsUnlockedBag;
    private bool rewardIsUnlockedOutfit;

    void Start()
    {

        PlayerPrefs.SetInt("index", 2);

        rewardIsEquippedShoes = PlayerPrefs.GetInt("_rewardIsEquippedShoes", 0) == 1;
        rewardIsEquippedCap = PlayerPrefs.GetInt("_rewardIsEquippedCap", 0) == 1;
        rewardIsEquippedBag = PlayerPrefs.GetInt("_rewardIsEquippedBag", 0) == 1;
        rewardIsEquippedOutfit = PlayerPrefs.GetInt("_rewardIsEquippedOutfit", 0) == 1;

        rewardIsUnlockedShoes = PlayerPrefs.GetInt("_rewardIsUnlockedShoes", 0) == 1;
        rewardIsUnlockedCap = PlayerPrefs.GetInt("_rewardIsUnlockedCap", 0) == 1;
        rewardIsUnlockedBag = PlayerPrefs.GetInt("_rewardIsUnlockedBag", 0) == 1;
        rewardIsUnlockedOutfit = PlayerPrefs.GetInt("_rewardIsUnlockedOutfit", 0) == 1;

        //SHOE SCROLL ITEM
        lockedItems[0].SetActive(!rewardIsUnlockedShoes);
        unlockedItems[0].SetActive(rewardIsUnlockedShoes);
        equipButtons[0].SetActive(!rewardIsEquippedShoes);
        unequipButtons[0].SetActive(rewardIsEquippedShoes);

        //CAP SCROLL ITEM
        lockedItems[1].SetActive(!rewardIsUnlockedCap);
        unlockedItems[1].SetActive(rewardIsUnlockedCap);
        equipButtons[1].SetActive(!rewardIsEquippedCap);
        unequipButtons[1].SetActive(rewardIsEquippedCap);

        //BAG SCROLL ITEM
        lockedItems[2].SetActive(!rewardIsUnlockedBag);
        unlockedItems[2].SetActive(rewardIsUnlockedBag);
        equipButtons[2].SetActive(!rewardIsEquippedBag);
        unequipButtons[2].SetActive(rewardIsEquippedBag);

        //OUTFIT SCROLL ITEM
        lockedItems[3].SetActive(!rewardIsUnlockedOutfit);
        unlockedItems[3].SetActive(rewardIsUnlockedOutfit);
        equipButtons[3].SetActive(!rewardIsEquippedOutfit);
        unequipButtons[3].SetActive(rewardIsEquippedOutfit);

    }

    void Update()
    {

            if (SimpleInput.GetButtonDown("OnEquipShoes"))
            {
                PlayerPrefs.SetInt("_rewardIsEquippedShoes", 1); //SHOES WEAR
                equipButtons[0].SetActive(false); unequipButtons[0].SetActive(true);
            }
            if (SimpleInput.GetButtonDown("OnEquipCap"))
            {
                PlayerPrefs.SetInt("_rewardIsEquippedCap", 1); //CAP WEAR
                equipButtons[1].SetActive(false); unequipButtons[1].SetActive(true);
            }
            if (SimpleInput.GetButtonDown("OnEquipBag"))
            {
                PlayerPrefs.SetInt("_rewardIsEquippedBag", 1); //BAG WEAR
                equipButtons[2].SetActive(false); unequipButtons[2].SetActive(true);
            }
            if (SimpleInput.GetButtonDown("OnEquipOutfit"))
            {
                PlayerPrefs.SetInt("_rewardIsEquippedOutfit", 1); //OUTFIT WEAR
                equipButtons[3].SetActive(false); unequipButtons[3].SetActive(true);
            }

            if (SimpleInput.GetButtonDown("OnUnequipShoes"))
            {
                PlayerPrefs.SetInt("_rewardIsEquippedShoes", 0); //SHOES REMOVE
                equipButtons[0].SetActive(true); unequipButtons[0].SetActive(false);
            }
            if (SimpleInput.GetButtonDown("OnUnequipCap"))
            {
                PlayerPrefs.SetInt("_rewardIsEquippedCap", 0); //CAP REMOVE
                equipButtons[1].SetActive(true); unequipButtons[1].SetActive(false);
            }
            if (SimpleInput.GetButtonDown("OnUnequipBag"))
            {
                PlayerPrefs.SetInt("_rewardIsEquippedBag", 0); //BAG REMOVE
                equipButtons[2].SetActive(true); unequipButtons[2].SetActive(false);
            }
            if (SimpleInput.GetButtonDown("OnUnequipOutfit"))
            {
                PlayerPrefs.SetInt("_rewardIsEquippedOutfit", 0); //OUTFIT REMOVE
                equipButtons[3].SetActive(true); unequipButtons[3].SetActive(false);
            }

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
