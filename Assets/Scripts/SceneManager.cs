using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{

    public Button homeBtn;
    // Start is called before the first frame update
    void Start()
    {
        homeBtn.onClick.AddListener(NextScene);
    }

    void NextScene()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
