
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    [SerializeField] private Image loadingFillHUD;


    void Start()
    {

        int countdown = 2;
        StartCoroutine(LoadingToStart(countdown));
        Time.timeScale = 1;

    }

    IEnumerator LoadingToStart(int _countdown)
    {

        while (_countdown > 0)
        {

            yield return new WaitForSeconds(1f);

            _countdown--;

        }

        int index = PlayerPrefs.GetInt("index", 1);
        StartCoroutine(LoadAsynchronously(index));

    }

    IEnumerator LoadAsynchronously(int _index)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(_index);

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingFillHUD.fillAmount = progress;

            yield return null;

        }

    }
}
