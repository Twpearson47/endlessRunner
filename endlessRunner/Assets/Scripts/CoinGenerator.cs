using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool;
    public ObjectPooler rockPool;
    public ObjectPooler cratePool;
    public float distanceCoins;
    public bool obstacleSpawning;

    void Start()
    {
        obstacleSpawning = false;    
    }

    public void SpawnCoins(Vector3 startPosition)
    {
        if (coinPool.transform.childCount < ObjectPooler.pooledAmount)
        {
            Debug.Log(startPosition);

            GameObject coin1 = coinPool.GetPooledObject();
            coin1.transform.position = startPosition;
            coin1.SetActive(true);

            GameObject coin2 = coinPool.GetPooledObject();
            coin2.transform.position = new Vector3(startPosition.x - distanceCoins, startPosition.y, startPosition.z);
            coin2.SetActive(true);

            GameObject coin3 = coinPool.GetPooledObject();
            coin3.transform.position = new Vector3(startPosition.x + distanceCoins, startPosition.y, startPosition.z);
            coin3.SetActive(true);
        }
    }

    public void SpawnRock(Vector3 startPosition02)
    {
        if (Mathf.RoundToInt(Movement.meters) >= 150)
        {
            if (rockPool.transform.childCount < ObjectPooler.pooledAmount02)
            {
                Debug.Log(startPosition02);

                GameObject rock1 = rockPool.GetPooledObject();
                rock1.transform.position = startPosition02;
                rock1.SetActive(true);
                obstacleSpawning = true;
            }
        }
    }

    public void SpawnCrate(Vector3 startPosition02)
    {
        if ((Mathf.RoundToInt(Movement.meters) >= 250) && obstacleSpawning == false)
        {
            if (cratePool.transform.childCount < ObjectPooler.pooledAmount02)
            {
                Debug.Log(startPosition02);

                GameObject crate1 = cratePool.GetPooledObject();
                crate1.transform.position = startPosition02;
                crate1.SetActive(true);
            }
        }
        else
        {
            obstacleSpawning = false;
        }
    }
}
