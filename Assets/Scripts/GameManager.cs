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
}
