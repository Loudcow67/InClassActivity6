using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TileManager : MonoBehaviour
{
    private Queue<GameObject> tilePool;

    public int maxTiles;

    // Start is called before the first frame update
    void Awake()
    {
        tilePool = new Queue<GameObject>();
        buildTilePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void buildTilePool()
    {
        for (int count = 0; count < maxTiles; count++)
        {
            var tempTile = TileFactory.Instance().CreateTile();
            tempTile.SetActive(false);
            tilePool.Enqueue(tempTile);
        }
    }

    public GameObject GetTile()
    {
        var tempTile = tilePool.Dequeue();
        tempTile.SetActive(true);
        return tempTile;
    }

    public void returnTile(GameObject tile)
    {
        tile.SetActive(false);
        tilePool.Enqueue(tile);
    }
}
