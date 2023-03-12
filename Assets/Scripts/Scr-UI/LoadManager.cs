using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{

    [SerializeField] 
    private Transform content;

    [SerializeField] 
    private GameObject[] foodAdapter;

    [SerializeField]
    private List<Sprite> healthyFoods;

    [SerializeField]
    private List<Sprite> junkFoods;

    private void Start()
    {

        /**foreach (Sprite food in healthyFoods)
        {
            GameObject newFood = Instantiate(preFabButton, scrollViewContent);
            if (newFood.TryGetComponent<ScrollViewItem>(out ScrollViewItem item))
            {
                item.ChangeImage(food);
            }
        }**/

    }

    private void LoadFoods()
    {

        bool isHealthy = true;

        content.ClearChildren();

        if (isHealthy)
        {

            for (int j = 0; j < 3; j++)
            {



            }


        }/*

        for (int i = 0; i < 10; i++)
        {

            GameObject newItem = Instantiate(foodAdapter, Rooms);
            if (newItem.TryGetComponent(out FoodAdapter item))
            {



            }
        
        }*/

    }

}
