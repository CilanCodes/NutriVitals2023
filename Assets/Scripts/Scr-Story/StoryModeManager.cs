using System.Collections;
using TMPro;
using UnityEngine;

public class StoryModeManager : MonoBehaviour
{
    [SerializeField] private GameObject panelUserName;
    [SerializeField] private GameObject panelSelectCharacter;
    [SerializeField] private GameObject panelStoryTime;
    [SerializeField] private GameObject panelVerification;

    [SerializeField] private GameObject submitButton;
    [SerializeField] private TMP_InputField inputUserName;

    private string userNameHolder;

    private bool isUserNamePanelDone;
    private bool isSelectCharacterPanelDone;
    public static bool IsGameStoryBegin { get; private set; }

    private void Start()
    {
        panelUserName.SetActive(true);
        panelSelectCharacter.SetActive(false);
        panelStoryTime.SetActive(false);
        panelVerification.SetActive(false);

        IsGameStoryBegin = false;
    }

    void Update()
    {

        submitButton.SetActive(inputUserName.text.Length > 3);

        if (IsGameStoryBegin)
        {
            StartCoroutine(StartGameStory());
            IsGameStoryBegin = false;
        }

        #region FOR STORY SCREEN
        if (SimpleInput.GetButtonDown("OnSubmitName"))
        {
            panelUserName.SetActive(false);
            panelVerification.SetActive(true);
            isUserNamePanelDone = true;

            userNameHolder = inputUserName.text.Trim().ToUpper();
            
        }

        if (SimpleInput.GetButtonDown("OnSelectCharacter"))
        {
            panelSelectCharacter.SetActive(false);
            panelVerification.SetActive(true);
            isSelectCharacterPanelDone = true;

        }

        if (SimpleInput.GetButtonDown("OnVerifySubmit"))
        {
            if (isUserNamePanelDone)
            {
                FindObjectOfType<User>().UserName = userNameHolder;
                StoryTextManager.userName = userNameHolder;
                panelVerification.SetActive(false);
                panelSelectCharacter.SetActive(true);
                isUserNamePanelDone = false;
            }
            if (isSelectCharacterPanelDone)
            {
                panelVerification.SetActive(false);
                panelStoryTime.SetActive(true);
                isSelectCharacterPanelDone = false;
                IsGameStoryBegin = true;
                StoryTextManager.isStoryTextChangeStarts = true;
            }
        }

        #endregion

    }

    IEnumerator StartGameStory()
    {
        yield return new WaitForSeconds(0.3f);
        panelStoryTime.GetComponent<Animator>().SetTrigger("OnStartStory");
    }
}
