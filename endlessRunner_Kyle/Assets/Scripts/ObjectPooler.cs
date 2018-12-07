using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;
    public static int pooledAmount = 6;
    List<GameObject> pooledObjects;

	void Start ()
    {
        pooledObjects = new List<GameObject>();
        /*
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject, gameObject.transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        */
	}

    public GameObject GetPooledObject()
    {
        //for(int i = 0; i < pooledObjects.Count; i++)
        //{
        //if(!pooledObjects[i].activeInHierarchy)
        //{
        //return pooledObjects[i];
        //}
        //}
        
        GameObject obj = (GameObject)Instantiate(pooledObject, gameObject.transform);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;

    }
}
