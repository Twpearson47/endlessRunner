using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSpriteSwap : MonoBehaviour
{

    public Sprite[] blockSprites; //the three different block patterns
    public Sprite[] mummySprites; //the three different mummy patterns
    public Sprite[] goddessSprites; //the four different goddess patterns
    public SpriteRenderer[] panels; //the panels of the walls
    public int switchCount;    //the number of panels before the scenery changes level (from blocks to mummies to goddesses)
    private int counter;       // the number of times the sprites change 
    private float levelf;
    private int level;   // the level 

    void Start()
    {
        panels = GetComponentsInChildren<SpriteRenderer>();
        counter = 0;
        levelf = 0.0f;
        level = 0;
        if (switchCount <= 0)
        {
            Debug.Log("SwitchCount must be a positive, non-zero integer - this code will now set it to 1");
            switchCount = 1;
        }
    }

    public void ChangeBackgroundSprite(int leftIndex)
    {
        levelf = (counter / switchCount);
        level = (int)levelf;

        if (level == 0)    //level 0 use block sprite
        {
            int randomIndex = Random.Range(0, blockSprites.Length);
            panels[leftIndex].sprite = blockSprites[randomIndex];
        }

        if (level == 1) // level 1 use the mummy sprite
        {
            int randomIndex = Random.Range(0, mummySprites.Length);
            panels[leftIndex].sprite = mummySprites[randomIndex];
        }

        if (level == 2) // level 2 use goddess sprite
        {
            int randomIndex = Random.Range(0, goddessSprites.Length);
            panels[leftIndex].sprite = goddessSprites[randomIndex];
        }

        if (level >= 3) // level 3 go back to level 0
        {
            counter = 0;
        }

        counter++;
    }

}
