using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    private bool isGameStoryBegin;

    private void Start()
    {
        panelUserName.SetActive(true);
        panelSelectCharacter.SetActive(false);
        panelStoryTime.SetActive(false);
        panelVerification.SetActive(false);

        submitButton.SetActive(false);
        isGameStoryBegin = false;
}

    void Update()
    {

        if (isGameStoryBegin) {
            StartCoroutine(StartGameStory());
            isGameStoryBegin = false;
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
                isGameStoryBegin = true;
                StoryTextManager.isStoryTextChangeStarts = true;
            }
        }

        // Check if the input field has any characters
        if (inputUserName.text.Length > 3)
        {
            // Enable the button if there is text
            submitButton.SetActive(true);
        }
        else
        {
            // Disable the button if there is no text
            submitButton.SetActive(false);
        }
        #endregion
    }

    IEnumerator StartGameStory()
    {
        yield return new WaitForSeconds(0.3f);
        panelStoryTime.GetComponent<Animator>().SetTrigger("OnStartStory");
    }
}
