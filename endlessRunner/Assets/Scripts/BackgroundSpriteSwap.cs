using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSpriteSwap : MonoBehaviour
{

    public Sprite[] blockSprites; //there are currently three different block patterns
    public Sprite[] mummySprites; //there are three different mummy patterns
    public Sprite[] goddessSprites; //there are four different goddess patterns
    public SpriteRenderer[] panels; //the three panels
    public int switchCount;    //the number of panels before the scenery changes (from blocks to mummies to goddesses)
    private int counter;       // the number of times the sprites change 
    private int panelIndex;      //the index of the panel to switch (should always be the panel currently behind the player)

    void Start()
    {
        panels = GetComponentsInChildren<SpriteRenderer>();
        counter = 0;
        panelIndex = 0;
    }

    public void ChangeBackgroundSprite()
    {
        if (counter <= switchCount)    //                if (counter < 3)// when the counter gets to 0, 1 2 etc up to switchCount change the Blocks scenery
        {
            int randomIndex = Random.Range(0, blockSprites.Length);
            Debug.Log("Blocks: counter, panelIndex, blocksprites.length, randomIndex " + counter + panelIndex + blockSprites.Length + randomIndex);
            panels[panelIndex].sprite = blockSprites[randomIndex];
            panelIndex++;
            while (panelIndex >= panels.Length)
            {
                panelIndex = panelIndex - (panels.Length);
            }
            counter++;
        }

        if (counter > switchCount && counter <= switchCount * 2) // when the counter is (switchCount to switchCount*2 -1) (3,4 or 5) change the mummy sprite
        {
            int randomIndex = Random.Range(0, mummySprites.Length);
            Debug.Log("Mummy: counter, panelIndex, mummySprites.Length, randomIndex " + counter + panelIndex + mummySprites.Length + randomIndex);
            panels[panelIndex].sprite = mummySprites[randomIndex];
            panelIndex++;
            while (panelIndex >= panels.Length)
            {
                panelIndex = panelIndex - (panels.Length);
            }
            counter++;
        }

        if (counter > (switchCount * 2) && counter <= switchCount * 3) // when the counter is  \(switchCount*2 to switchCount*3 -1) 6,7,8 change the goddess sprite
        {
            int randomIndex = Random.Range(0, goddessSprites.Length);
                   Debug.Log("Goddess: counter, panelIndex, goddessSprites.Length, randomIndex " + counter + panelIndex + goddessSprites.Length + randomIndex);
            panels[panelIndex].sprite = goddessSprites[randomIndex];
            panelIndex++;
            while (panelIndex >= panels.Length)
            {
                panelIndex = panelIndex - (panels.Length);
            }
            counter++;
        }
        if (counter > switchCount * 3)
        {
            counter = 0;
        }
    }

}
