using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodInfoScript : MonoBehaviour
{

    [SerializeField]
    private ToggleGroup foodNavigationUIPanel;

    [SerializeField]
    private Image foodUIImage;

    [SerializeField]
    private TextMeshProUGUI[] foodUITexts;

    private string[,,] FOODS;

    [SerializeField]
    private List<Sprite> healthyFoods;

    [SerializeField]
    private List<Sprite> junkFoods;

    void Start()
    {

        FOODS = ENV.FOODS;
        LoadFoods();

    }

    void Update()
    {

        if (SimpleInput.GetButtonUp("OnFoodNavigation"))

            LoadFoods();

    }

    private void Food(Sprite _foodImage, string[] _foodTexts)
    {

        foodUIImage.sprite = _foodImage;
        foodUITexts[0].text = _foodTexts[0];
        foodUITexts[2].text = _foodTexts[1];
        foodUITexts[1].text = _foodTexts[2];

    }

    public void OnFood(Sprite _foodImage, string[] _foodTexts) => Food(_foodImage, _foodTexts);

    private void LoadFoods()
    {

        List<FoodModel> foods = new();
        string foodNavigation = FindObjectOfType<GameManager>().GetToggleName(foodNavigationUIPanel);
        bool isHealthy = foodNavigation.Equals("TabHealthyFood");
        int foodCategory =
            isHealthy
            ? 0
            : 3;

        /*int counter = 0;
        for (int category = foodCategory; category < foodCategory + 3; category++)
        {

            for (int food = 0; food < 3; food++)
            {

                FoodModel foodModel = new();
                foodModel.Image = isHealthy
                    ? healthyFoods[counter++]
                    : junkFoods[counter++];
                foodModel.Text[0] = FOODS[category, 0, food];
                foodModel.Text[1] = GetFoodCategory(category);
                foodModel.Text[2] = FOODS[category, 1, food];
                Debug.Log(foodModel);
                foods.Add(foodModel);
            }

        }*/
        int minSize = Mathf.Min(healthyFoods.Count, junkFoods.Count);
        int counter = 0;
        for (int category = foodCategory; category < foodCategory + 3; category++)
        {

            for (int food = 0; food < 3; food++)
            {

                FoodModel foodModel = new();
                if (counter < minSize)
                {

                    foodModel.Image = isHealthy
                    ? healthyFoods[counter]
                    : junkFoods[counter];

                }
                
                foodModel.Text[0] = FOODS[category, 0, food];
                foodModel.Text[1] = GetFoodCategory(category);
                foodModel.Text[2] = FOODS[category, 1, food];
                Debug.Log(foodModel);
                foods.Add(foodModel);
                counter++;
            }

        }

        Debug.Log(foods);
        FindObjectOfType<LoadManager>().OnLoadFoods(foods, isHealthy);

    }

    private string GetFoodCategory(int category) => category switch
    {

        1 => "Grow Food",

        2 => "Glow Food",

        3 => "Sugary Food",

        4 => "Fatty Food",

        5 => "Processed Food",

        _ => "Go Food",

    };

    private void OnLoadFoods() => LoadFoods();

}
