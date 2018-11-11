using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingParallax : MonoBehaviour {

    public float backgroundSize;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;


	// Use this for initialization
	void Start () {

        cameraTransform = camera.main.transform;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
