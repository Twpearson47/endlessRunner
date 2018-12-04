using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    public float speed = 0.1f;

    void Update()
    {
        if (Movement.isDead == false)
        {
            if (PauseMenu.GameIsPaused == false)
            {
                gameObject.transform.position += new Vector3(speed, 0, 0);
            }
        }
    }

    void ObjectDestroy(Collider2D objectCollider)
    {
        Destroy(objectCollider.gameObject);
    }

    void ObjectDestroy02(Collision2D objectCollision)
    {
        Destroy(objectCollision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Scarab"))
        {
            ObjectDestroy(collision);
        }
        if (collision.gameObject.tag == ("Urn"))
        {
            ObjectDestroy(collision);
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
        {
            if (collider.gameObject.tag == ("Death"))
        {
            ObjectDestroy02(collider);
        }
    }
}
