using System.Collections;
using System.Linq;
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

    /*public ToggleGroup characterToggleGroup;
    public GameObject[] characterToggles;
    public int characterIndex;*/

    public GameObject[] characterToggles;
    int characterIndex;

    void Start()
    {

        IsSkipUIButtonVisible = false;
        decisionState = 0;
        characterIndex = -1;
    }

    void Update()
    {

        FindObjectOfType<GameManager>()
            .Animator
            .SetInteger("decisionState", decisionState);

        UserName = userNameUIInputField
            .text
            .Trim();

        UIButtons[0].SetActive(UserName.Length > 3);
        UIButtons[2].SetActive(UserName.Length < 3);

        if (SimpleInput.GetButtonDown("OnCharacterA"))
            characterIndex = 0;

        if (SimpleInput.GetButtonDown("OnCharacterB"))
            characterIndex = 1;

        if (SimpleInput.GetButtonDown("OnCharacterC"))
            characterIndex = 2;

        if (SimpleInput.GetButtonDown("OnCharacterD"))
            characterIndex = 3;

        UIButtons[3].SetActive(characterIndex < 0);
        UIButtons[4].SetActive(characterIndex >= 0);
        

        //Debug.Log(characterIndex);
        //Debug.Log( characterIndex != 5);
        //Debug.Log(!(characterIndex != 5));

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
                FindObjectOfType<User>().UserName = UserName.ToUpper();

            }
            else if (decisionState == 2)
            {
                CheckSelectedCharacter(false);
                decisionState = 3;
            }

                

            else if (decisionState == 3)
            {
                PlayerPrefs.SetInt("_characterIndex", characterIndex);
                decisionState = 4;
                Skip();
                StartStory();

            }

        }

        if (SimpleInput.GetButtonDown("OnClose"))
        {
            CheckSelectedCharacter(true);

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

        //FindObjectOfType<SoundManager>().OnClicked();
        string character = FindObjectOfType<GameManager>().GetToggleName(characterUIPanel);
        FindObjectOfType<User>().UserCharacterState = GetCharacterState(character);

        Debug.Log(GetCharacterState(character));
        //characterIndex = GetCharacterState(character);
        

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

        textState = 0;
        StartCoroutine(StartStoryToStart());

    }

    private IEnumerator StartStoryToStart()
    {

        storyUIText.text = string.Empty;
        foreach (char letter in ENV.STORY_TEXT[textState++].ToCharArray())
        {

            storyUIText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
        yield return new WaitForSeconds(6.5f);

        if (textState < ENV.STORY_TEXT.Length)

            StartCoroutine(StartStoryToStart());

        else
        {

            FindObjectOfType<User>().OnSave();
            GameManager.OnLoadScene(2);

        }

    }

    private bool IsSkipUIButtonVisible
    {

        set => UIButtons[1].SetActive(value);

    }


    private void CheckSelectedCharacter(bool isReset)
    {

        if (isReset)
        {
            /*for (int i = 0; i > 6; i++)
            {
                characterToggles[i].SetActive(true);
            }*/
            characterToggles[4].SetActive(true);
            characterToggles[5].SetActive(true);
            characterToggles[0].SetActive(true);
            characterToggles[1].SetActive(true);
            characterToggles[2].SetActive(true);
            characterToggles[3].SetActive(true);
            characterIndex = -1;

        }
        else
        {
            characterToggles[0].SetActive(characterIndex == 0);
            characterToggles[1].SetActive(characterIndex == 1);
            characterToggles[2].SetActive(characterIndex == 2);
            characterToggles[3].SetActive(characterIndex == 3);
            characterToggles[4].SetActive(characterIndex == 0 || characterIndex == 1);
            characterToggles[5].SetActive(characterIndex == 2 || characterIndex == 3);
        }

    }

    public static string UserName { get; private set; }

}
