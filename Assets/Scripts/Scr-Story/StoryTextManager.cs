using System.Collections;
using TMPro;
using UnityEngine;

public class StoryTextManager : MonoBehaviour
{

    [SerializeField] 
    private TextMeshProUGUI coachStoryText;

    [SerializeField] 
    private float typingSpeed = 0.04f;

    private void StartStory()
    {

        string initialText = string.Format("HELLO {0},\nIM MR. NUTRI V. ITALS\nAND I WILL BE YOUR COACH", UserName);

        for (int i = 0; i < 5; i++)

            StartCoroutine(GetText(
                i == 0
                ? initialText
                : ENV.STORY_TEXT[i - 1]));

        GameManager.OnLoadScene(2);

    }

    private IEnumerator GetText(string _text)
    {

        coachStoryText.text = string.Empty;
        foreach (char letter in _text.ToCharArray())
        {

            coachStoryText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
        yield return new WaitForSeconds(6.5f);

    }

    public static string UserName { private get; set; }

    public void OnStartStory() => StartStory();

}
