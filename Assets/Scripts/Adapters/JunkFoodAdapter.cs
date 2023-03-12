using UnityEngine;
using UnityEngine.UI;

public class JunkFoodAdapter : MonoBehaviour
{

    [SerializeField]
    private Image foodUIImage;

    private string foodName;
    private string foodCategory;
    private string foodDescription;

    private void OnClick()
    {



    }

    public Sprite Food
    {

        set => foodUIImage.sprite = value;

    }

    public string FoodName
    {

        set => foodName = value;

    }

    public string FoodCategory
    {

        set => foodCategory = value;

    }

    public string FoodDescription
    {

        set => foodDescription = value;

    }

}
