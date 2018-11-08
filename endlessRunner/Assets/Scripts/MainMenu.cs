using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public bool textState;
    public Image menuText;
    void Start()
    {
        textState = true;
    }

    void Update()
    {
        if (textState == true)
        {
            Invoke("DisableText", 0.55f);
        }
        if (textState == false)
        {
            Invoke("EnableText", 0.55f);
        }
    }

    void DisableText()
    {
        menuText.enabled = false;
        textState = false;
    }

    void EnableText()
    {
        menuText.enabled = true;
        textState = true;
    }
}