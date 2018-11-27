using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Text scarabText;
    public static float scarabCount;
    
	void Update ()
    {
        scarabText.text = scarabCount.ToString("000");
	}
}
