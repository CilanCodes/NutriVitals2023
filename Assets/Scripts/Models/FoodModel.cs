using UnityEngine;

public class FoodModel
{

    private string[] text = new string[]
    {

        "",
        "",
        "",

    };

    public Sprite Image { get; set; }

    public string[] Text
    {

        get => text;
        set => text = value;

    }

}
