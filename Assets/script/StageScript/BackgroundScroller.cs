using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject[] groundTiles;
    public float tileLength = 100f;
    public float scrollSpeed = 5f;

    private Queue<GameObject> tileQueue;

    // Start is called before the first frame update
    void Start()
    {
        tileQueue = new Queue<GameObject>(groundTiles);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject tile in tileQueue)
        {
            tile.transform.Translate(Vector3.forward * scrollSpeed * Time.deltaTime);
        }

        GameObject GetLastTile()
        {
            GameObject[] tiles = tileQueue.ToArray();
            return tiles[tiles.Length - 1];
        }

        GameObject firstTile = tileQueue.Peek();
        if (firstTile.transform.position.z < -tileLength)
        {
            GameObject movedTile = tileQueue.Dequeue();
            GameObject lastTile = GetLastTile();
            Vector3 newPos = lastTile.transform.position + Vector3.forward * tileLength;
            movedTile.transform.position = newPos;
            tileQueue.Enqueue(movedTile);
        }
    }
}
