using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimation : MonoBehaviour {
    
    private Animator breakableObj;

    void Start()
    {
        breakableObj = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            breakableObj.SetBool("Destroy", true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            breakableObj.SetBool("Destroy", true);
        }
        if (col.gameObject.tag == ("Faller"))
        {
            breakableObj.SetBool("Destroy", true);
        }
    }
}
