using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{

    [SerializeField] 
    private Transform content;

    [SerializeField] 
    private GameObject[] itemAdapter;

    private void LoadFoods(List<FoodModel> _foods, bool _isHealthy)
    {

        GameObject foodAdapter =
            _isHealthy
            ? itemAdapter[0]
            : itemAdapter[1];

        content.ClearChildren();
        foreach (FoodModel food in _foods)
        {

            GameObject newItem = Instantiate(foodAdapter, content);
            if (newItem.TryGetComponent(out FoodAdapter item))
            {

                item.FoodImage = food.Image;
                item.FoodTexts = food.Text;
       
            }
        
        }

    }

    public void OnLoadFoods(List<FoodModel> _foods, bool _isHealthy) => LoadFoods(_foods, _isHealthy);

}
