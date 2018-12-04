using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFaller : MonoBehaviour
{

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

    void ObjectFall(Collision2D objectCollision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == ("Death"))
        {
            ObjectFall(collider);
        }
    }
}
