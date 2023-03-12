using UnityEngine;
using UnityEngine.UI;

public class FoodAdapter : MonoBehaviour
{

    [SerializeField]
    private Image foodUIImage;

    private string[] foodTexts;

    private void Click() => FindObjectOfType<FoodInfoScript>().OnFood(FoodImage, FoodTexts);

    public Sprite FoodImage
    {

        get => foodUIImage.sprite;
        set => foodUIImage.sprite = value;

    }

    public string[] FoodTexts
    {

        get => foodTexts;
        set => foodTexts = value;

    }

    public void OnClick() => Click();

}
