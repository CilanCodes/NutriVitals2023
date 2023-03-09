using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoachFactsManager : MonoBehaviour
{

    public string[] coachFacts = {
        "Go foods give you energy and fuel for maintaining a healthy brain.",
        "The body develops, becomes stronger, and becomes healthier with the support of Grow foods.",
        "Glow foods help the immune system become stronger.",
        "Frozen or prepared meals are often the most highly processed foods.",
        "Too much added sugar in food and beverages can lead to health issues like weight gain.",
        "Eating high amounts of saturated fat can increase LDL or bad cholesterol.",
        "Being in a low energy state might result in hunger, anxiety, and even small sleep problems.",
        "A high energy balance can be uncomfortable because overeating can increase blood pressure and cholesterol in our bodies.",
    };

    [SerializeField] private TextMeshProUGUI PauseFact;
    [SerializeField] private TextMeshProUGUI GameOverFact;
    // Start is called before the first frame update
    void Start()
    {
            GameOverFact.text =  coachFacts[Random.Range(0, coachFacts.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if(SimpleInput.GetButtonDown("OnPromptPaused")) {
            PauseFact.text = coachFacts[Random.Range(0, coachFacts.Length)];
        }

    }

}
