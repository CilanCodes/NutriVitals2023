using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{

    [SerializeField]
    private ToggleGroup characterUIPanel;

    void Update()
    {

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

}
