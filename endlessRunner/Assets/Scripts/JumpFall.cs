using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFall : MonoBehaviour {

    public float fallMultiplier = 4f;

    Rigidbody2D rb;

    private void Awake()
    {
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }









    private void Update()
    {
        if (rb.velocity.y < 0)
        {

            StartCoroutine(GravityControl());
            

        }
    }
    

    IEnumerator GravityControl()
    {
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(0.1f);
        rb.gravityScale = 1f;
        rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

    }
}
