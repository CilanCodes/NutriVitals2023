using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{

    [SerializeField]
    private GameObject skipUIButton;

    [SerializeField]
    private ToggleGroup characterUIPanel;

    void Start()
    {

        IsSkipUIButtonVisible = false;

    }

    void Update()
    {

        if (StoryModeManager.IsGameStoryBegin
            && !IsSkipUIButtonVisible)

            Skip();

        if (SimpleInput.GetButtonDown("OnCharacterPick"))

            OnCharacterPick();

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

        get => skipUIButton.activeSelf;
        set => skipUIButton.SetActive(value); 

    }

}
