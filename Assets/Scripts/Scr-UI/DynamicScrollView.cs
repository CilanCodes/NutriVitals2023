using System.Collections.Generic;
using UnityEngine;

public class DynamicScrollView : MonoBehaviour
{
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private GameObject preFabButton;
    [SerializeField] private List<Sprite> healthyFoods;
    [SerializeField] private List<Sprite> junkFoods;

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
}
