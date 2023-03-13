using UnityEngine;
using TMPro;
using System.Collections;

public class GameScreenManager : MonoBehaviour
{

    [Header("MAIN SECTION")]
    [SerializeField] 
    private GameObject countdownHUD;

    [SerializeField] 
    private TextMeshProUGUI adviceUIText;

    [SerializeField]
    private TextMeshProUGUI countdownUIText;

    void Start()
    {

        PlayerPrefs.SetInt("index", 2);
        int countdown = 3;
        StartCoroutine(CountdownToStart(countdown));

    }

    void Update()
    {

        if (SimpleInput.GetButtonDown("OnRestart"))
        {

            GameManager.OnLoadScene(4);
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

}
