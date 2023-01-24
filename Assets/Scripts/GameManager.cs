using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Invoke("OpenHomeScreen", 5f);
        }

    }

    private void OpenHomeScreen()
    {
        PlayerPrefs.SetInt("index", 2);
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        //Update your ProjectSettings>Player>OtherSettings>ActiveInputHandling>Both
        //SimpleInput.GetButton <-- Holding a Button
        //SimpleInput.GetButtonDown <-- Upon Pressing, execute
        //SimpleInput.GetButtonUp <-- Upon Release, execute
        if (SimpleInput.GetButtonDown("OnRunNow"))
        {
            PlayerPrefs.SetInt("index", 4);
            SceneManager.LoadScene(0);
        }
    }
}
