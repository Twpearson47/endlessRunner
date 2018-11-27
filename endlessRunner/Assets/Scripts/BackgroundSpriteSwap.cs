using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSpriteSwap : MonoBehaviour
{
//   public List<3> spriteSwapList;
//    public Sprite spriteBlock1;
//    public Sprite spriteBlock2;
//    public Sprite spriteBlock3;

//    public Sprite spriteMummy1;
//    public Sprite spriteMummy2;
//    public Sprite spriteMummy3;


    public Sprite[] blockSprites;
    public Sprite[] mummySprites;
    public Sprite[] goddessSprites;

    private SpriteRenderer spriteRendererPanel1;
  //  private SpriteRenderer spriteRendererBlock2;
  //  private SpriteRenderer spriteRendererBlock3;


    void Start()
    {
        spriteRendererPanel1 = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject 1
        if (spriteRendererPanel1.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRendererPanel1.sprite = blockSprites[0]; // set the sprite to the first Block sprite spriteBlock1
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Movement.isDead == false && PauseMenu.GameIsPaused == false) // If the E key is pushed down
//        if (meters>=3) // when the player gets the distance to change the scenery
        {
            ChangeTheBlockSprite(); // call method to change block sprites
        }
        if (Input.GetKeyDown(KeyCode.R) && Movement.isDead == false && PauseMenu.GameIsPaused == false) // If the E key is pushed down
        {
            ChangeTheMummySprite(); // call method to change the mummy sprites
        }
        if (Input.GetKeyDown(KeyCode.T) && Movement.isDead == false && PauseMenu.GameIsPaused == false) // If the E key is pushed down
        {
            ChangeTheGoddessSprite(); // call method to change the goddess sprites
        }

    }

    public void ChangeTheBlockSprite()
    {
        int randomIndex = Random.Range(0, 3);
        spriteRendererPanel1.sprite = blockSprites[randomIndex];
    }

    public void ChangeTheMummySprite()
    {
        int randomIndex = Random.Range(0, 3);
        spriteRendererPanel1.sprite = mummySprites[randomIndex];
    }

    public void ChangeTheGoddessSprite()
    {
        int randomIndex = Random.Range(0, 3);
        spriteRendererPanel1.sprite = goddessSprites[randomIndex];
    }

}
