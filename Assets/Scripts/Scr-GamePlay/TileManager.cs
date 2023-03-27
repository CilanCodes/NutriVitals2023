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
            else if (HUDManager.scorePoints <= 3000 || HUDManager.scorePoints >= 1501)
            {
                SpawnTileMap(map2TilePreFabs);
            }
            else if (HUDManager.scorePoints <= 4500 || HUDManager.scorePoints >= 3001)
            {
                SpawnTileMap(map3TilePreFabs);
            }
            else if (HUDManager.scorePoints <= 6000 || HUDManager.scorePoints >= 4501)
            {
                SpawnTileMap(map4TilePreFabs);
            }
            else if (HUDManager.scorePoints >= 6001)
            {
                SpawnTileMap(map1TilePreFabs);
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
