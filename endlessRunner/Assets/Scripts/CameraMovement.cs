using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        Vector3 newPosition = player.transform.position + offset;
        newPosition.y = 0;
        transform.position = newPosition;
    }
}