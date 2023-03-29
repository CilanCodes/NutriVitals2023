using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    [SerializeField]
    private GameObject skipUIButton;

    [SerializeField]
    private TextMeshProUGUI endStoryUIText;

    [SerializeField]
    private float typingSpeed = 0.04f;

    public GameObject[] map1TilePreFabs;
    public GameObject[] map2TilePreFabs;
    public GameObject[] map3TilePreFabs;
    public GameObject[] map4TilePreFabs;
    public float zSpawn = 0;
    public float tileLength = 40;
    public int numberOfTiles = 3;
    private int textState;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;

    private void Start()
    {

        skipUIButton.SetActive(false);

        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                RandomTile(0, map1TilePreFabs);
            }
            else
            {
                RandomTile(Random.Range(0, map1TilePreFabs.Length), map1TilePreFabs);
            }

        }

        //FOR REMOVAL ONLY FOR TESTING
        PlayerPrefs.SetInt("_hasReachedScore", 0);
        //FOR TESTING ONLY
    }

    void Update()
    {
        //Debug.Log((playerTransform.position.z - 50) + ">" + (zSpawn - (numberOfTiles * tileLength)));
        if (playerTransform.position.z - 50 > zSpawn - (numberOfTiles * tileLength))
        {

            if (HUDManager.scorePoints <= 500)
            {
                SpawnTileMap(map1TilePreFabs);
            }
            else if (HUDManager.scorePoints <= 700)
            {
                SpawnTileMap(map2TilePreFabs);
                PlayerPrefs.SetInt("_rewardIsUnlockedShoes", 1);

                if(GameScreenManager.hasReachedScore == 0)
                {
                    FindObjectOfType<GameScreenManager>().RewardObtainedShoe();
                    GameScreenManager.hasReachedScore = 1500;
                    PlayerPrefs.SetInt("_hasReachedScore", 1500);
                }

            }
            else if (HUDManager.scorePoints <= 1000)
            {
                SpawnTileMap(map3TilePreFabs);
                PlayerPrefs.SetInt("_rewardIsUnlockedCap", 1);

                if (GameScreenManager.hasReachedScore == 1500)
                {
                    FindObjectOfType<GameScreenManager>().RewardObtainedCap();
                    GameScreenManager.hasReachedScore = 3000;
                    PlayerPrefs.SetInt("_hasReachedScore", 3000);
                }
            }
            else if (HUDManager.scorePoints <= 1200)
            {
                SpawnTileMap(map4TilePreFabs);
                PlayerPrefs.SetInt("_rewardIsUnlockedBag", 1);

                if (GameScreenManager.hasReachedScore == 3000)
                {
                    FindObjectOfType<GameScreenManager>().RewardObtainedBag();
                    GameScreenManager.hasReachedScore = 4500;
                    PlayerPrefs.SetInt("_hasReachedScore", 4500);
                }
            }
            else
            {

                SpawnTileMap(map1TilePreFabs);
                PlayerPrefs.SetInt("_rewardIsUnlockedOutfit", 1);

                if (GameScreenManager.hasReachedScore == 4500)
                {

                    FindObjectOfType<GameScreenManager>().RewardObtainedOutfit();
                    GameScreenManager.hasReachedScore = 6000;
                    PlayerPrefs.SetInt("_hasReachedScore", 6000);

                    int score = GameScreenManager.hasReachedScore;
                    string name = FindObjectOfType<User>().UserName;

                    LeaderboardModel leaderboard = new(score, name);
                    FindObjectOfType<User>().Leaderboard.Add(leaderboard);
                    FindObjectOfType<User>().OnSave();


                    StateManager.IsMoving = false;
                    //Time.timeScale = 0;
                    //FOR REMOVE
                    FindObjectOfType<GameManager>().OnTrigger("endStory");
                    EndStory();
                    Skip();
                    //FOR REMOVE ONLY FOR TESTING

                    
                    
                }

            }

            DeleteTile();
        }

        if (SimpleInput.GetButtonDown("OnSkip"))

            GameManager.OnLoadScene(2);

    }


    public void SpawnTileMap(GameObject[] tileMap)
    {
        RandomTile(Random.Range(0, tileMap.Length), tileMap);
    }

    public void RandomTile(int tileIndex, GameObject[] tileMap)
    {

        GameObject go = Instantiate(
            tileMap[tileIndex],
            transform.forward * zSpawn,
            transform.rotation
            );

        activeTiles.Add(go);

        zSpawn += tileLength;
    }



    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private async void Skip()
    {

        await Task.Delay(5000);
        skipUIButton.SetActive(true);

    }

    private void EndStory()
    {

        textState = 0;
        StartCoroutine(EndStoryToStart());

    }

    private IEnumerator EndStoryToStart()
    {

        endStoryUIText.text = string.Empty;
        foreach (char letter in ENV.END_STORY_TEXT[textState++].ToCharArray())
        {

            endStoryUIText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
        yield return new WaitForSeconds(6.5f);

        if (textState < ENV.END_STORY_TEXT.Length)

            StartCoroutine(EndStoryToStart());

        else
        {

            FindObjectOfType<User>().OnSave();
            GameManager.OnLoadScene(2);

        }

    }

}
