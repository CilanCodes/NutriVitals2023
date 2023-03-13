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

        int countdown = 3;
        StartCoroutine(CountdownToStart(countdown));

    }

    void Update()
    {

        if (SimpleInput.GetButtonDown("OnRestart"))
        {

            GameManager.OnLoadScene(4);
            /*SceneManager.LoadScene("GameScreen");
            Time.timeScale = 1;
            //Debug.Log(PlayerController.targetPosition.z);
            FoodManager.isReplayAgain = true;*/

        }

        if (SimpleInput.GetButtonDown("OnPaused"))
        {
            //Debug.Log("Paused");
            /*FindObjectOfType<GameManager>().OnTrigger("InActivateOverlayStatus");
            FindObjectOfType<GameManager>().OnTrigger("ActivePause");*/
            Time.timeScale = 0;
            //HUDManager.swipeEnabled = false;
            Advice();
        }

        //BLOCKS ENERGY DECREMENT
        if (Time.timeScale == 0
            || StateManager.PowerUpTypeState == StateManager.POWER_UP_TYPE.GO)
        {

            HUDManager.ResetEnergyPoints();
            return;

        }

        //DECREASE ENERGY OVER TIME
        AdjustmentFunctions.DecreaseEnergyOverTime();

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

        countdownHUD.SetActive(false);

    }

    public bool IsPlaying { get; private set; }

    public void GetAdvice() => Advice();

}
