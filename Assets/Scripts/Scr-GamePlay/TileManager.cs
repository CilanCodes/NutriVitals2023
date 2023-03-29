using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] map1TilePreFabs;
    public GameObject[] map2TilePreFabs;
    public GameObject[] map3TilePreFabs;
    public GameObject[] map4TilePreFabs;
    public float zSpawn = 0;
    public float tileLength = 40;
    public int numberOfTiles = 3;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;

    private void Start()
    {
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

    }

    void Update()
    {
        //Debug.Log((playerTransform.position.z - 50) + ">" + (zSpawn - (numberOfTiles * tileLength)));
        if (playerTransform.position.z - 50 > zSpawn - (numberOfTiles * tileLength))
        {

            if (HUDManager.scorePoints <= 1500)
            {
                SpawnTileMap(map1TilePreFabs);
            }
            else if (HUDManager.scorePoints <= 3000)
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
            else if (HUDManager.scorePoints <= 4500)
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
            else if (HUDManager.scorePoints <= 6000)
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
                }
            }


            DeleteTile();
        }
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


}
