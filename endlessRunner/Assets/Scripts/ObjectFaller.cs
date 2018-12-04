using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFaller : MonoBehaviour {
    
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
}
