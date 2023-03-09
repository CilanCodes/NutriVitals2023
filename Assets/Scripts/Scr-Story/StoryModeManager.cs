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

    private bool isUserNamePanelDone;
    private bool isSelectCharacterPanelDone;

    private void Start()
    {
        submitButton.SetActive(false);

        StartCoroutine(StartGameStory());

        
    }

    void Update()
    {
        #region FOR STORY SCREEN
        if (SimpleInput.GetButtonDown("OnSubmitName"))
        {
            panelUserName.SetActive(false);
            panelVerification.SetActive(true);
            isUserNamePanelDone = true;
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
                panelVerification.SetActive(false);
                panelSelectCharacter.SetActive(true);
                isUserNamePanelDone = false;
            }
            if (isSelectCharacterPanelDone)
            {
                panelVerification.SetActive(false);
                panelStoryTime.SetActive(true);
                isSelectCharacterPanelDone = false;
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
