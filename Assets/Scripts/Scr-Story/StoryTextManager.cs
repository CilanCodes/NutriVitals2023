using System.Collections;
using TMPro;
using UnityEngine;

public class StoryTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coachStoryText;

    [SerializeField] private float typingSpeed = 0.04f;
    private int index = 0;

    public static bool isStoryTextChangeStarts;
    public static string userName;

    private string[] storyTexts = {
        "I WILL HELP YOU UNDERSTAND \n THAT PROPER NUTRITION \n IS AS IMPORTANT AS PHYSICAL TRAINING",
        "YOUR TRAINING GROUND \n WILL BE FILLED WITH \n HEALTHY FOODS AND TEMPTING JUNK FOODS",
        "ALONG THE WAY, \n YOU MUST CHOOSE THE \n RIGHT FOODS  TO \n FUEL YOUR BODY AND \n IMPROVE YOUR PERFORMANCE",
        "GOODLUCK MY DEAR TRAINEE \n I WILL BE HERE WITH YOU \n ALONG THE WAY"
    };

    private string initialText;


    private void Start()
    {
        isStoryTextChangeStarts = false;
    }

    private void Update()
    {
        if (userName != null)
        {
            initialText = "HELLO " + userName + "," + "\nIM MR. NUTRI V. ITALS" + "\nAND I WILL BE YOUR COACH";
        }
        else
        {
            initialText = "HELLO THERE" + "," + "\nIM MR. NUTRI V. ITALS" + "\nAND I WILL BE YOUR COACH";
        }

        if (isStoryTextChangeStarts)
        {
            StartCoroutine(TextStoryBegin());
            isStoryTextChangeStarts = false;
        }
    }

    IEnumerator TextStoryBegin()
    {

        coachStoryText.text = string.Empty;
        yield return new WaitForSeconds(2.0f);

        foreach (char a in initialText.ToCharArray())
        {
            coachStoryText.text += a;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(6.5f);

        coachStoryText.text = string.Empty;
        foreach (char c in storyTexts[index].ToCharArray())
        {
            coachStoryText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(6.5f);

        FindObjectOfType<GameManager>().OnLoadScene(2);

    }
    
}
