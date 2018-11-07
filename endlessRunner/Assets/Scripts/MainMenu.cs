using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Image canvasText1;
    void Start()
    {
        Invoke("DisableText", 5f);//invoke after 5 seconds
    }
    void DisableText()
    {
        canvasText1.enabled = false;
    }
}