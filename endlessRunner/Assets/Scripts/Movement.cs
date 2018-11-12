using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.15f;
    public float JumpHeight;
    public bool isGrounded;

    private Rigidbody2D rb;

    void Start()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(speed, 0, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }
    }
}
