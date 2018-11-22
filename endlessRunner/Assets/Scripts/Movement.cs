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

    public Text meterLabel;

    public bool isGrounded;
    public static bool isDead;

    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startTime = Time.time;
        isGrounded = true;
        isDead = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
        }
        if ((PauseMenu.GameIsPaused == false) || (isDead == true))
        {
            gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        currentTime = Time.time;
        float meters = (currentTime - startTime) * (Mathf.RoundToInt(speed) + 10);
        meterLabel.text = Mathf.RoundToInt(meters). ToString();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == ("Death"))
        {
            isDead = true;
        }
    }
}
