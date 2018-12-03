using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingParallax : MonoBehaviour {

    public bool scrolling, paralax, spawningCoins, spawningObstacles;
    public BackgroundSpriteSwap backGrounds;

    public float backgroundSize;
    public float paralaxSpeed;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;

    private CoinGenerator theCoinGenerator;
    public float randomCoin;
    public float randomRock;
    public float randomBlade;
    public float randomCrate;
    public float randomCoffin;
    public float randomUrn;
    public int spawningUrns;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);
        leftIndex = 0;
        rightIndex = layers.Length - 1;
        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }

    private void Update()
    {
        if (Movement.isDead == false)
        {
            if (PauseMenu.GameIsPaused == false)
            {
                if (paralax)
                {
                    float deltaX = cameraTransform.position.x - lastCameraX;
                    transform.position += Vector3.right * (deltaX * paralaxSpeed);
                }

                lastCameraX = cameraTransform.position.x;

                if (scrolling)
                {
                    if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
                        ScrollLeft();

                    if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
                        ScrollRight();
                }
            }
        }

        if (Mathf.RoundToInt(Movement.meters) >= 150)
        {
            randomRock = 30;
            if (Mathf.RoundToInt(Movement.meters) >= 250)
            {
                randomRock = 20;
                randomBlade = 50;
                randomUrn = 100;
                spawningUrns = 1;
                if (Mathf.RoundToInt(Movement.meters) >= 600)
                {
                    randomRock = 10;
                    randomBlade = 50;
                    randomCoffin = 70;
                    randomUrn = 100;
                    spawningUrns = 2;
                }
            }
        }
    }

    private void ScrollLeft()
    {
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }

    private void ScrollRight()
    {
        float randomGeneration = Random.Range(0f, 100f);
        if ((Random.Range(0f, 100f) < randomCoin) && spawningCoins == true)
        {
            theCoinGenerator.SpawnCoins(new Vector3((transform.position.x * -1f) + 20f, transform.position.y + 2f, transform.position.z));
        }

        if (Mathf.RoundToInt(Movement.meters) >= 150)
        {
            if ((randomGeneration < randomRock) && spawningObstacles == true)
            {
                theCoinGenerator.SpawnRock(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.7f, transform.position.z));
            }

            if (Mathf.RoundToInt(Movement.meters) >= 250)
            {
                if ((randomGeneration > randomRock) && (randomGeneration < randomBlade) && spawningObstacles == true)
                {
                    theCoinGenerator.SpawnBlade(new Vector3((transform.position.x * -1f) + 20f, transform.position.y, transform.position.z));
                }
                if ((randomGeneration > randomBlade) && (randomGeneration < randomUrn) && spawningObstacles == true && spawningUrns == 1)
                {
                    theCoinGenerator.SpawnUrn(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.2f, transform.position.z));
                }

                if (Mathf.RoundToInt(Movement.meters) >= 600)
                {
                    if ((randomGeneration > randomCrate) && (randomGeneration < randomCoffin) && spawningObstacles == true)
                    {
                        theCoinGenerator.SpawnCoffin(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.2f, transform.position.z));
                    }
                    if ((randomGeneration > randomCoffin) && (randomGeneration < randomUrn) && spawningObstacles == true && spawningUrns == 2)
                    {
                        theCoinGenerator.SpawnUrn(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.2f, transform.position.z));
                    }
                }
            }
        }

        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x - backgroundSize);
        if (backGrounds != null)
        {
            backGrounds.ChangeBackgroundSprite(leftIndex);
        }

        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x - backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
}
