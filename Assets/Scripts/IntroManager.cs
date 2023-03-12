using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] UIButtons;

    [SerializeField]
    private TMP_InputField userNameUIInputField;

    [SerializeField]
    private ToggleGroup characterUIPanel;

    private int decisionState;
    private string username;

    void Start()
    {

        IsSkipUIButtonVisible = false;
        decisionState = 0;

    }

    void Update()
    {

        if (SimpleInput.GetButtonDown("OnCharacterPick"))

            OnCharacterPick();

        if (SimpleInput.GetButtonDown("OnSkip"))

            GameManager.OnLoadScene(2);

        FindObjectOfType<GameManager>()
            .Animator
            .SetInteger("decisionState", decisionState);

        username = userNameUIInputField
            .text
            .Trim();

        UIButtons[0].SetActive(username.Length > 3);

        if (SimpleInput.GetButtonDown("OnSubmit"))
        {

            if (decisionState == 0)

                decisionState = 1;

            else if (decisionState == 1)
            {

                decisionState = 2;
                GetUserName(username);

            }
            else if (decisionState == 3)
            {

                decisionState = 4;
                FindObjectOfType<IntroManager>().OnSkip();
                FindObjectOfType<StoryTextManager>().OnStartStory();

            }

        }

        if (SimpleInput.GetButtonDown("OnClose"))
        {

            if (decisionState == 1)

                decisionState = 0;

            else if (decisionState == 3)

                decisionState = 2;

        }

    }
    private void GetUserName(string _username)
    {

        _username.ToUpper();
        FindObjectOfType<User>().UserName = _username;
        StoryTextManager.UserName = _username;

    }

    private void OnCharacterPick()
    {

        FindObjectOfType<SoundManager>().OnClicked();

        string character = FindObjectOfType<GameManager>().GetToggleName(characterUIPanel);
        FindObjectOfType<User>().UserCharacterState = GetCharacterState(character);

    }

    private int GetCharacterState(string _character) => _character switch
    {

        "CharacterB" => 1,

        "CharacterC" => 2,

        "CharacterD" => 3,

        _ => 0,

    };

    private async void Skip()
    {

        await Task.Delay(5000);
        IsSkipUIButtonVisible = true;

    }

    private bool IsSkipUIButtonVisible 
    {

        set => UIButtons[1].SetActive(value); 

    }

    public void OnSkip() => Skip();

}
