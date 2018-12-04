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
    public float randomCoinR;
    public float randomCoinG;
    public float randomRock;
    public float randomBlade;
    public float randomCrate;
    public float randomScorpion;
    public float randomMummy;
    public float randomCoffin;
    public float randomUrn;
    public int spawningUrns;
    public int spawningScarabs;

    public float coinHeight;

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

        coinHeight = Random.Range(-1f, 2.8f);

        if (Mathf.RoundToInt(Movement.meters) >= 150)
        {
            randomCoin = 100;
            randomRock = 30;
            if (Mathf.RoundToInt(Movement.meters) >= 250)
            {
                randomRock = 20;
                randomBlade = 50;
                randomUrn = 100;
                spawningUrns = 1;
                if (Mathf.RoundToInt(Movement.meters) >= 500)
                {
                    randomCoin = 70;
                    randomCoinR = 100;
                    randomRock = 15;
                    randomBlade = 45;
                    randomCrate = 60;
                    spawningUrns = 2;
                    if (Mathf.RoundToInt(Movement.meters) >= 800)
                    {
                        randomCoin = 40;
                        randomCoinR = 80;
                        randomCoinG = 100;
                        randomRock = 10;
                        randomBlade = 30;
                        randomCrate = 45;
                        randomScorpion = 70;
                        spawningUrns = 3;
                        if (Mathf.RoundToInt(Movement.meters) >= 1250)
                        {
                            randomRock = 0;
                            randomBlade = 15;
                            randomCrate = 25;
                            randomScorpion = 50;
                            randomMummy = 80;
                            spawningUrns = 4;
                            if (Mathf.RoundToInt(Movement.meters) >= 1750)
                            {
                                randomBlade = 10;
                                randomCrate = 10;
                                randomScorpion = 25;
                                randomMummy = 55;
                                randomCoffin = 80;
                            }
                        }
                    }
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
            theCoinGenerator.SpawnCoins(new Vector3((transform.position.x * -1f) + 20f, transform.position.y + coinHeight, transform.position.z));
        }
        if ((Random.Range(0f, 100f) < 70) && spawningObstacles == true)
        {
            theCoinGenerator.SpawnFalling(new Vector3((transform.position.x * -1f) + 20f, transform.position.y + 3.7f, transform.position.z));
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
                    if ((Random.Range(0f, 100f) < 30))
                    {
                        theCoinGenerator.SpawnUrn(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.28f, transform.position.z));
                    }
                }

                if (Mathf.RoundToInt(Movement.meters) >= 500)
                {
                    if ((randomGeneration > randomBlade) && (randomGeneration < randomCrate) && spawningObstacles == true)
                    {
                        theCoinGenerator.SpawnCrate(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.4f, transform.position.z));
                    }
                    if ((randomGeneration > randomCrate) && (randomGeneration < randomUrn) && spawningObstacles == true && spawningUrns == 2)
                    {
                        if ((Random.Range(0f, 100f) < 30))
                        {
                            theCoinGenerator.SpawnUrn(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.28f, transform.position.z));
                        }
                    }
                    if ((Random.Range(0f, 100f) > randomCoin) && (Random.Range(0f, 100f) < randomCoinR) && spawningCoins == true)
                    {
                        theCoinGenerator.SpawnCoins2(new Vector3((transform.position.x * -1f) + 20f, transform.position.y + coinHeight, transform.position.z));
                    }

                    if (Mathf.RoundToInt(Movement.meters) >= 800)
                    {
                        if ((randomGeneration > randomCrate) && (randomGeneration < randomScorpion) && spawningObstacles == true)
                        {
                            theCoinGenerator.SpawnScorpion(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.55f, transform.position.z));
                        }
                        if ((randomGeneration > randomScorpion) && (randomGeneration < randomUrn) && spawningObstacles == true && spawningUrns == 3)
                        {
                            if ((Random.Range(0f, 100f) < 30))
                            {
                                if ((Random.Range(0f, 100f) < 70))
                                {
                                    theCoinGenerator.SpawnUrn(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.28f, transform.position.z));
                                }
                                if ((Random.Range(0f, 100f) > 70) && (Random.Range(0f, 100f) < 100))
                                {
                                    theCoinGenerator.SpawnUrn2(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 1.75f, transform.position.z));
                                }
                            }
                        }
                        if ((Random.Range(0f, 100f) > randomCoinR) && (Random.Range(0f, 100f) < randomCoinG) && spawningCoins == true)
                        {
                            theCoinGenerator.SpawnCoins3(new Vector3((transform.position.x * -1f) + 20f, transform.position.y + coinHeight, transform.position.z));
                        }

                        if (Mathf.RoundToInt(Movement.meters) >= 1250)
                        {
                            if ((randomGeneration > randomScorpion) && (randomGeneration < randomMummy) && spawningObstacles == true)
                            {
                                theCoinGenerator.SpawnMummy(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 0.83f, transform.position.z));
                            }
                            if ((randomGeneration > randomMummy) && (randomGeneration < randomUrn) && spawningObstacles == true && spawningUrns == 4)
                            {
                                if ((Random.Range(0f, 100f) < 30))
                                {
                                    if ((Random.Range(0f, 100f) < 70))
                                    {
                                        theCoinGenerator.SpawnUrn(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.28f, transform.position.z));
                                    }
                                    if ((Random.Range(0f, 100f) > 70) && (Random.Range(0f, 100f) < 100))
                                    {
                                        theCoinGenerator.SpawnUrn2(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 1.75f, transform.position.z));
                                    }
                                }
                            }

                            if (Mathf.RoundToInt(Movement.meters) >= 1750)
                            {
                                if ((randomGeneration > randomMummy) && (randomGeneration < randomCoffin) && spawningObstacles == true)
                                {
                                    theCoinGenerator.SpawnCoffin(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.2f, transform.position.z));
                                }
                            }
                        }
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
