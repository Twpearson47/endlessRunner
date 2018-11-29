using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimation : MonoBehaviour {
    
    private Animator breakableRock;

    void Start()
    {
        breakableRock = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            breakableRock.SetBool("Destroy", true);
        }
    }
}
