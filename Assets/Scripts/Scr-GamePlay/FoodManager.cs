using System.Collections;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public static bool isReplayAgain;

    [SerializeField] private GameObject[] foodItems;

    [SerializeField] private Sprite[] goSprites;
    [SerializeField] private Sprite[] growSprites;
    [SerializeField] private Sprite[] glowSprites;
    [SerializeField] private Sprite[] junkSprites;

    private string[] foodCategory = { "Go", "Grow", "Glow", "Junk" };
    private int[] itemPosition;

    public static float elapsedTime;

    private void Start()
    {
        if (isReplayAgain)
        {
            StartCoroutine(WaitFor3Seconds());
        }
        else
        {
            
            if (StateManager.PowerUpTypeState == StateManager.POWER_UP_TYPE.GO)
            {
                #region FOR GO POWER UP FOOD SPAWN
                int noOfFoods = foodItems.Length;
                int goSelectedFood = Random.Range(0, goSprites.Length);
                int randomLane = Random.Range(0, 2);

                for (int i = 0; i < noOfFoods; i++)
                {
                    if (randomLane == 0 &&
                        (i == 0 || i == 3 || i == 6 || i == 9))
                    {
                        GameObject goFoodItem = foodItems[i];
                        goFoodItem.SetActive(true);

                        SpriteRenderer spriteRenderer = goFoodItem.GetComponent<SpriteRenderer>();

                        goFoodItem.tag = "Go";
                        spriteRenderer.sprite = goSprites[goSelectedFood];
                    }

                    else if (randomLane == 1 &&
                        (i == 1 || i == 4 || i == 7 || i == 10))
                    {
                        GameObject goFoodItem = foodItems[i];
                        goFoodItem.SetActive(true);

                        SpriteRenderer spriteRenderer = goFoodItem.GetComponent<SpriteRenderer>();

                        goFoodItem.tag = "Go";
                        spriteRenderer.sprite = goSprites[goSelectedFood];
                    }

                    else if (randomLane == 2 &&
                        (i == 2 || i == 5 || i == 8 || i == 11))
                    {
                        GameObject goFoodItem = foodItems[i];
                        goFoodItem.SetActive(true);

                        SpriteRenderer spriteRenderer = goFoodItem.GetComponent<SpriteRenderer>();

                        goFoodItem.tag = "Go";
                        spriteRenderer.sprite = goSprites[goSelectedFood];
                    }

                }

            }
            #endregion
            else
            {
                #region FOR RANDOM NON POWER UP FOOD SPAWN

                int noOfFoods;

                if (StateManager.PowerUpTypeState == StateManager.POWER_UP_TYPE.GROW 
                    || StateManager.PowerUpTypeState == StateManager.POWER_UP_TYPE.GLOW)
                {
                    noOfFoods = Random.Range(2, 4);
                }
                else
                {
                    noOfFoods = Random.Range(1, 3);
                }

                itemPosition = new int[noOfFoods];

                for (int i = 0; i < noOfFoods; i++)
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
                            spriteRenderer.sprite = growSprites[Random.Range(0, growSprites.Length)];
                            break;

                        case "Glow":
                            spriteRenderer.sprite = glowSprites[Random.Range(0, glowSprites.Length)];
                            break;

                        case "Junk":
                            spriteRenderer.sprite = junkSprites[Random.Range(0, junkSprites.Length)];
                            break;
                    }

                }
                #endregion
            }
        }
    }

    IEnumerator WaitFor3Seconds()
    {
        //Debug.Log("Wait for 3 Secs");

        yield return new WaitForSeconds(1);

        //Debug.Log("Time's Up");

        isReplayAgain = false;

    }

}

