using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingParallax : MonoBehaviour {

    public bool scrolling, paralax, spawningCoins;

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
        if ((Random.Range(0f, 100f) < randomCoin) && spawningCoins == true)
        {
            theCoinGenerator.SpawnCoins(new Vector3((transform.position.x * -1f) + 20f, transform.position.y + 2f, transform.position.z));
        }
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x - backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
}
