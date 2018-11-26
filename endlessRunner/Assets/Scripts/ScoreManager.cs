using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Text scarabText;
    public float scarabCount;
    private ScoreManager theScoreManager;


	void Start () {

        theScoreManager = FindObjectOfType<ScoreManager>();

	}

	void Update () {

        scarabText.text = scarabCount.ToString("000");
	}
}
