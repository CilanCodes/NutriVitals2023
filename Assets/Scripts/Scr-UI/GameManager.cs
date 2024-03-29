using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private Animator animator;

    void Awake()
    {

        DontDestroy();

    }

    void Update()
    {

        if (animator == null
            && SceneManager.GetActiveScene().buildIndex != 3)

            animator = FindObjectOfType<AnimatorController>().Animator;

        if (SimpleInput.GetButtonDown("OnHomeScreen"))
        {
            FindObjectOfType<SoundManager>().OnClicked();
            LoadScene(2);
        }


        if (SimpleInput.GetButtonDown("OnReturn"))
        {
            FindObjectOfType<SoundManager>().OnClicked();
            Time.timeScale = 1;
            SceneManager.LoadScene(2);

        }

        if (SimpleInput.GetButtonDown("OnClose1"))
        {
            FindObjectOfType<SoundManager>().OnClicked();

            FindObjectOfType<GameManager>().OnTrigger(ENV.CLOSE);

            if (SceneManager.GetActiveScene().buildIndex != 4)
            {
                Time.timeScale = 1;
                StateManager.IsMoving = true;

            }

        }

    }

    private static void LoadScene(int _index)
    {

        PlayerPrefs.SetInt("index", _index);
        SceneManager.LoadScene(0);

    }

    private void DontDestroy()
    {

        if (FindObjectsOfType(GetType()).Length > 1)

            Destroy(gameObject);

        else

            DontDestroyOnLoad(gameObject);

    }

    public static void OnLoadScene(int _index) => LoadScene(_index);

    /*
     * Upon calling this method it must return a string value of current active toggle belong to the toggle group.
     */
    private string ToggleName(ToggleGroup _toggleGroup)
    {

        /*
         * Let's locally declare a TOGGLE field.
         * Also, let's initialize it's value to a PARAMETERIZED TOGGLE GROUP
         * that returns a value of current active TOGGLE belong to that TOGGLE GROUP.
         */
        Toggle toggle = _toggleGroup
            .ActiveToggles()
            .FirstOrDefault();

        // Lastly, let's returns a string value of current active toggle.
        return toggle.name.ToString();

    }

    /*
     * Let's publicly declare a GetToggle method that has a string value.
     * Also, let's add a publicly get method init.
     */
    public string GetToggleName(ToggleGroup _toggleGroup) => ToggleName(_toggleGroup);

    public Animator Animator => animator;

    public void OnTrigger(string _trigger) => animator.SetTrigger(_trigger);

}
