using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{

    [SerializeField] private GameObject[] foodItems;
    
    [SerializeField] private Sprite[] goSprites;
    [SerializeField] private Sprite[] growSprites;
    [SerializeField] private Sprite[] glowSprites;
    [SerializeField] private Sprite[] junkSprites;

    private string[] foodCategory = { "Go", "Grow", "Glow", "Junk" };
    public int[] itemPosition;

    public static float elapsedTime;

    private void Start()
    {

      

        if (PlayerController.targetPosition.z > 40)
        {

        

        int noOfFoods = Random.Range(1, 4);

        for ( int i=1 ; i < noOfFoods; i++)
        {
            int randomFoodItemPosition = Random.Range(0, foodItems.Length);
            itemPosition[i] = randomFoodItemPosition;

            GameObject randomFoodItem = foodItems[randomFoodItemPosition];
            randomFoodItem.SetActive(true);

            SpriteRenderer spriteRenderer = randomFoodItem.GetComponent<SpriteRenderer>();

            string randomFoodCategory = foodCategory[Random.Range(0, foodCategory.Length)];
            randomFoodItem.tag = randomFoodCategory;


            switch (randomFoodCategory)
            {
                case "Go":
                    spriteRenderer.sprite = goSprites[Random.Range(0, goSprites.Length)];
                    break;

                case "Grow":
                    spriteRenderer.sprite = growSprites[Random.Range(0, goSprites.Length)];
                    break;

                case "Glow":
                    spriteRenderer.sprite = glowSprites[Random.Range(0, goSprites.Length)];
                    break;

                case "Junk":
                    spriteRenderer.sprite = junkSprites[Random.Range(0, goSprites.Length)];
                    break;
            }



        }


    }


    }

}
