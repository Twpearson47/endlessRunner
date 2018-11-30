using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingParallax2 : MonoBehaviour
{

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
    public float randomCrate;
    public float randomCoffin;

    private void Start()
    {
        backGrounds = GetComponent<BackgroundSpriteSwap>();
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
                randomCrate = 50;
                if (Mathf.RoundToInt(Movement.meters) >= 600)
                {
                    randomRock = 10;
                    randomCrate = 50;
                    randomCoffin = 70;
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
                if ((randomGeneration > randomRock) && (randomGeneration < randomCrate) && spawningObstacles == true)
                {
                    theCoinGenerator.SpawnCrate(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.4f, transform.position.z));
                }

                if (Mathf.RoundToInt(Movement.meters) >= 600)
                {
                    if ((randomGeneration > randomCrate) && (randomGeneration < randomCoffin) && spawningObstacles == true)
                    {
                        theCoinGenerator.SpawnCoffin(new Vector3((transform.position.x * -1f) + 20f, transform.position.y - 2.2f, transform.position.z));
                    }
                }
            }
        }

        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x - backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
        if (backGrounds != null)
        {
            print(leftIndex);
            backGrounds.ChangeBackgroundSprite();
        }

    }
}
