using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FoodInfoScript : MonoBehaviour
{
    [SerializeField] private ToggleGroup navigationPanel;
    [SerializeField] private GameObject healthyFoodContent;
    [SerializeField] private GameObject junkFoodContent;

    [SerializeField] private Image imageSelectedFood;
    [SerializeField] private TextMeshProUGUI textTitleSelectedFood;
    [SerializeField] private TextMeshProUGUI textCategorySelectedFood;
    [SerializeField] private TextMeshProUGUI textDescSelectedFood;

    [SerializeField] private List<Sprite> foodSprites;
    [SerializeField] private List<string> foodButtons;
    [SerializeField] private List<string> foodCategory;
    [SerializeField] private List<string> foodDescriptions;


    private void Update()
    {
        switchContent();
        loopButton();

    }


    private string GetNavigation(ToggleGroup _toggleGroup)
    {

        Toggle navigation = _toggleGroup.ActiveToggles().FirstOrDefault();
        return navigation.name.ToString();

    }

    private void switchContent()
    {
        string navigation = GetNavigation(navigationPanel);
        if (navigation.Equals("TabHealthyFood"))
        {
            healthyFoodContent.SetActive(true);
            junkFoodContent.SetActive(false);
        }
        else
        {
            healthyFoodContent.SetActive(false);
            junkFoodContent.SetActive(true);
        }
    }

    public void selectedFood(Sprite image, string title, string category, string description)
    {
        imageSelectedFood.sprite = image;
        textTitleSelectedFood.text = title;
        textCategorySelectedFood.text = category;
        textDescSelectedFood.text = description;
    }

    private void loopButton()
    {
        int foodIndex = 0;
        foreach (string foodButton in foodButtons)
        {
            if (SimpleInput.GetButtonDown(foodButton))
            {
                Debug.Log(foodButton);
                Debug.Log(foodIndex);

                selectedFood(foodSprites[foodIndex], foodButtons[foodIndex], foodCategory[foodIndex], foodDescriptions[foodIndex]);

            }
            foodIndex += 1;
        }
    }

}
