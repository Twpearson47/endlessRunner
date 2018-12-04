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

    public Text meterLabel;
    public Text bestLabel;

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
        ScoreManager.scarabCount++;
        ScoreManager.scarabCount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Scarab"))
        {
            CollectCoin(collision);
        }
        if ((collision.gameObject.tag == ("Urn")) && isSliding == true)
        {
            CollectCoin2(collision);
            Sound.PlayOneShot(VaseHit);
        }
    }

    public void hasDied()
    {
        if (Mathf.RoundToInt(meters) > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(meters));
            bestLabel.text = Mathf.RoundToInt(meters).ToString("0000");
        }
    }
}
