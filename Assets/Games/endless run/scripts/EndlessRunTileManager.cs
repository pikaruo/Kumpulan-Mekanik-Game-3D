using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunTileManager : MonoBehaviour
{
    [Header("System Generate Infinite Tiles")]
    [SerializeField] private GameObject[] tilePrefabs;
    [SerializeField] private float zSpawn = 0;
    [SerializeField] private float tileLength = 30;
    [SerializeField] private int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }
    }

    private void Update()
    {
        if (playerTransform.position.z - 45 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject tile = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(tile);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

}
