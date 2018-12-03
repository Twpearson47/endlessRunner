using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrnAnimation : MonoBehaviour
{

    private Animator breakableObj;

    void Start()
    {
        breakableObj = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.tag == ("Player")) && Movement.isSliding == true)
        {
            breakableObj.SetBool("Destroy", true);
        }
    }
}
