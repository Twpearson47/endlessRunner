using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool;
    public ObjectPooler rockPool;
    public ObjectPooler bladePool;
    public ObjectPooler cratePool;
    public ObjectPooler scorpionPool;
    public ObjectPooler mummyPool;
    public ObjectPooler coffinPool;
    public ObjectPooler urnPool;
    public float distanceCoins;

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
        if (rockPool.transform.childCount < ObjectPooler.pooledAmount02)
        {
            Debug.Log(startPosition02);

            GameObject rock1 = rockPool.GetPooledObject();
            rock1.transform.position = startPosition02;
            rock1.SetActive(true);
        }
    }

    public void SpawnBlade(Vector3 startPosition02)
    {
        if (bladePool.transform.childCount < ObjectPooler.pooledAmount02)
        {
            Debug.Log(startPosition02);

            GameObject blade1 = bladePool.GetPooledObject();
            blade1.transform.position = startPosition02;
            blade1.SetActive(true);
        }
    }

    public void SpawnCrate(Vector3 startPosition02)
    {
        if (cratePool.transform.childCount < ObjectPooler.pooledAmount02)
        {
            Debug.Log(startPosition02);

            GameObject crate1 = cratePool.GetPooledObject();
            crate1.transform.position = startPosition02;
            crate1.SetActive(true);
        }
    }

    public void SpawnScorpion(Vector3 startPosition02)
    {
        if (scorpionPool.transform.childCount < ObjectPooler.pooledAmount02)
        {
            Debug.Log(startPosition02);

            GameObject scorpion1 = scorpionPool.GetPooledObject();
            scorpion1.transform.position = startPosition02;
            scorpion1.SetActive(true);
        }
    }

    public void SpawnMummy(Vector3 startPosition02)
    {
        if (mummyPool.transform.childCount < ObjectPooler.pooledAmount02)
        {
            Debug.Log(startPosition02);

            GameObject mummy1 = mummyPool.GetPooledObject();
            mummy1.transform.position = startPosition02;
            mummy1.SetActive(true);
        }
    }

    public void SpawnCoffin(Vector3 startPosition02)
    {
        if (coffinPool.transform.childCount < ObjectPooler.pooledAmount02)
        {
            Debug.Log(startPosition02);

            GameObject coffin1 = coffinPool.GetPooledObject();
            coffin1.transform.position = startPosition02;
            coffin1.SetActive(true);
        }
    }

    public void SpawnUrn(Vector3 startPosition02)
    {
        if (urnPool.transform.childCount < ObjectPooler.pooledAmount02)
        {
            Debug.Log(startPosition02);

            GameObject urn1 = urnPool.GetPooledObject();
            urn1.transform.position = startPosition02;
            urn1.SetActive(true);
        }
    }
}
