using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] UIButtons;

    [SerializeField]
    private TextMeshProUGUI storyUIText;

    [SerializeField]
    private TMP_InputField userNameUIInputField;

    [SerializeField]
    private ToggleGroup characterUIPanel;

    [SerializeField]
    private float typingSpeed = 0.04f;

    private int decisionState;
    private int textState;
    private string username;

    void Start()
    {

        IsSkipUIButtonVisible = false;
        decisionState = 0;

    }

    void Update()
    {

        FindObjectOfType<GameManager>()
            .Animator
            .SetInteger("decisionState", decisionState);

        username = userNameUIInputField
            .text
            .Trim();

        UIButtons[0].SetActive(username.Length > 3);

        if (SimpleInput.GetButtonDown("OnCharacterPick"))

            OnCharacterPick();

        if (SimpleInput.GetButtonDown("OnSkip"))

            GameManager.OnLoadScene(2);

        if (SimpleInput.GetButtonDown("OnSubmit"))
        {

            if (decisionState == 0)

                decisionState = 1;

            else if (decisionState == 1)
            {

                decisionState = 2;
                FindObjectOfType<User>().UserName = username.ToUpper();

            }
            else if (decisionState == 2)

                decisionState = 3;

            else if (decisionState == 3)
            {

                decisionState = 4;
                Skip();
                StartStory();

            }

        }

        if (SimpleInput.GetButtonDown("OnClose"))
        {

            if (decisionState == 1)
            {

                decisionState = 0;
                userNameUIInputField.text = "";

            }
            else if (decisionState == 3)

                decisionState = 2;

        }

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

    private void StartStory()
    {

        string initialText = string.Format("HELLO {0},\nIM MR. NUTRI V. ITALS\nAND I WILL BE YOUR COACH", username);
        textState = 0;
        StartCoroutine(GetText(initialText));

    }

    private IEnumerator GetText(string _text)
    {

        textState++;
        storyUIText.text = string.Empty;
        foreach (char letter in _text.ToCharArray())
        {

            storyUIText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
        yield return new WaitForSeconds(6.5f);

        if (textState < 5)
            
            StartCoroutine(GetText(ENV.STORY_TEXT[textState - 1]));

        else
            
            GameManager.OnLoadScene(2);

    }

    private bool IsSkipUIButtonVisible 
    {

        set => UIButtons[1].SetActive(value); 

    }

}
