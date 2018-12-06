using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 0.15f;
    public float JumpHeight;
    public float startTime;
    public float currentTime;
    public static float meters;

    public int scarabCount;
    public int endScarab;

    public bool newHighscore;
    public Text bestScore;

    public Text meterLabel;
    public Text bestLabel;
    public Text coinLabel;
    public Text finishedLabel;
    public Text endLabel;

    public bool isGrounded;
    public static bool isDead;
    public static bool isSliding;

    public AudioClip VaseHit;
    public AudioClip JumpGrunt;
    public AudioClip ObstacleHit;
    public AudioSource Sound;

    private Animator movingPlayer;
    private Rigidbody2D rb;

    void Start()
    {
        movingPlayer = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        bestLabel.text = PlayerPrefs.GetInt("HighScore", 0).ToString("0000");
        startTime = Time.time;
        isGrounded = true;
        isDead = false;
        isSliding = false;
        bestScore.enabled = false;
        scarabCount = 1;
        endScarab = PlayerPrefs.GetInt("CoinsCollected");
        coinLabel.text = endScarab.ToString("000");
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
            Sound.PlayOneShot(JumpGrunt);
            movingPlayer.SetBool("IsJumping", true);
        }
        if (Input.GetKeyUp("space"))
        {
            movingPlayer.SetBool("IsJumping", false);
        }
        if (Input.GetKey(KeyCode.DownArrow) && isGrounded == true)
        {
            isSliding = true;
            movingPlayer.SetBool("IsSliding", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isSliding = false;
            movingPlayer.SetBool("IsSliding", false);
        }
        if (isDead == false)
        {
            if (PauseMenu.GameIsPaused == false)
            {
                gameObject.transform.position += new Vector3(speed, 0, 0);
            }
            currentTime = Time.time;
            meters = (currentTime - startTime) * (Mathf.RoundToInt(speed) + 10);
            meterLabel.text = Mathf.RoundToInt(meters).ToString("0000");
        }
        if (newHighscore == true)
        {
            bestScore.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == ("Death"))
        {
            Debug.Log("Dead");
            isDead = true;
            Sound.PlayOneShot(ObstacleHit);
            hasDied();
        }
    }

    void CollectCoin(Collider2D coinCollider)
    {
        ScoreManager.scarabCount++;
        Destroy(coinCollider.gameObject);
    }

    void CollectCoin2(Collider2D coinCollider)
    {
        while (scarabCount < 3)
        {
            ScoreManager.scarabCount++;
            scarabCount++;
        }
        if (scarabCount == 3)
        {
            scarabCount = 1;
        }
        if (coinCollider.gameObject.tag == ("ScarabR"))
        {
            Destroy(coinCollider.gameObject);
        }
    }

    void CollectCoin3(Collider2D coinCollider)
    {
        while (scarabCount < 4)
        {
            ScoreManager.scarabCount++;
            scarabCount++;
        }
        if (scarabCount == 4)
        {
            scarabCount = 1;
        }
        if (coinCollider.gameObject.tag == ("ScarabG"))
        {
            Destroy(coinCollider.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Scarab"))
        {
            CollectCoin(collision);
        }
        if (collision.gameObject.tag == ("ScarabR"))
        {
            CollectCoin2(collision);
        }
        if (collision.gameObject.tag == ("ScarabG"))
        {
            CollectCoin3(collision);
        }
        if ((collision.gameObject.tag == ("Urn")) && isSliding == true)
        {
            CollectCoin2(collision);
            Sound.PlayOneShot(VaseHit);
        }
        if ((collision.gameObject.tag == ("UrnB")) && isSliding == true)
        {
            CollectCoin3(collision);
            Sound.PlayOneShot(VaseHit);
        }
    }

    public void hasDied()
    {
        if (Mathf.RoundToInt(meters) > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(meters));
            bestLabel.text = Mathf.RoundToInt(meters).ToString("0000");
            newHighscore = true;
        }
        PlayerPrefs.SetInt("CoinsCollected", endScarab + Mathf.RoundToInt(ScoreManager.scarabCount));
        coinLabel.text = (endScarab + Mathf.RoundToInt(ScoreManager.scarabCount)).ToString("000");
        finishedLabel.text = Mathf.RoundToInt(meters).ToString("0000");
        endLabel.text = (ScoreManager.scarabCount).ToString("000");
    }
}
