using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodInfoScript : MonoBehaviour
{

    /*[SerializeField] 
    private ToggleGroup navigationPanel;

    [SerializeField] 
    private Image foodUIImage;

    [SerializeField] 
    private TextMeshProUGUI[] foodUITexts;

    private void Update()
    {

        switchContent();
        loopButton();

    }
    
    private void Food(Sprite _foodImage, string[] _foodTexts)
    {

        foodUIImage.sprite = _foodImage;
        foodUITexts[0].text = _foodTexts[0];
        foodUITexts[2].text = _foodTexts[1];
        foodUITexts[1].text = _foodTexts[2];

    }

    public void OnFood(Sprite _foodImage, string[] _foodTexts) => Food(_foodImage, _foodTexts);

    private string GetNavigation(ToggleGroup _toggleGroup)
    {

        Toggle navigation = _toggleGroup.ActiveToggles().FirstOrDefault();
        return navigation.name.ToString();
        
    }

    private void switchContent()
    {
        string navigation = GetNavigation(navigationPanel);
        
    }

    public void selectedFood(Sprite image, string title, string category, string description)
    {
        foodUIImage.sprite = image;
        foodUITexts.text = title;
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
    }*/

}
