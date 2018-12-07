using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    public GameObject Rock;
    public int blockNum = 1;
    public int blockHeight = 1;

    public void PlaceObject(Vector2 cords)
    {
        float rnd = Random.value;

        if (rnd >= 0.3f && rnd < 0.7f)
        {
            Instantiate (Rock, new Vector2(cords.x, -2.4f), Quaternion.identity);
        }
    }

    void Start()
    {
        if (Random.value < 0.2f)
        {
            PlaceObject(new Vector2(blockNum, blockHeight));
        }
    }

    void Update()
    {

    }
}
