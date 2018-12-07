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
    public bool isSliding;
    public bool muteButton;

    public AudioClip VaseHit1;
    public AudioClip VaseHit2;
    public AudioClip VaseHit3;
    public AudioClip VaseHit4;
    public AudioClip JumpGrunt1;
    public AudioClip JumpGrunt2;
    public AudioClip Mummy;
    public AudioClip ObstacleHit;
    public AudioClip RockFall1;
    public AudioClip RockFall2;
    public AudioClip RockFall3;
    public AudioClip Rock1;
    public AudioClip Rock2;
    public AudioClip Slide1;
    public AudioClip Slide2;
    public AudioClip Scarab1;
    public AudioClip Scarab2;
    public AudioClip Crate;
    public AudioClip Scorpion;
    public AudioClip Death;
    public AudioSource Sound;

    public GameObject rock;
    private Animator movingPlayer;
    private Animator breakableRock;
    private Rigidbody2D rb;

    void Start()
    {
        movingPlayer = GetComponent<Animator>();
        breakableRock = rock.GetComponent<Animator>();
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
            movingPlayer.SetBool("IsJumping", true);
            SoundManager.instance.RandomizeSfx(JumpGrunt1, JumpGrunt2);
        }
        if (Input.GetKeyUp("space"))
        {
            movingPlayer.SetBool("IsJumping", false);
        }
        if (Input.GetKey(KeyCode.DownArrow) && isGrounded == true)
        {
            isSliding = true;
            movingPlayer.SetBool("IsSliding", true);
            SoundManager.instance.RandomizeSfx(Slide1, Slide2);
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

        if (col.gameObject.layer == 8)
        {
            SoundManager.instance.RandomizeSfx(Rock1, Rock2);
        }

        if (col.gameObject.layer == 9)
        {
            Sound.PlayOneShot(Scorpion);
        }

        if (col.gameObject.layer == 10)
        {
            Sound.PlayOneShot(Crate);
        }


        if (col.gameObject.tag == ("Death"))
        {
            Debug.Log("Dead");
            breakableRock.SetBool("Destroy", true);
            isDead = true;
            SoundManager.instance.musicSource.Stop();
            Sound.PlayOneShot(Death);
            hasDied();
        }
    }

    void CollectCoin(Collider2D coinCollider)
    {
        ScoreManager.scarabCount++;
        Destroy(coinCollider.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Scarab"))
        {
            CollectCoin(collision);
            SoundManager.instance.RandomizeSfx(Scarab1, Scarab2);
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
