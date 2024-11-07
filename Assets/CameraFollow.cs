using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // Player or object to follow
    public float smoothSpeed = 0.125f;  // Smoothing speed
    public Vector3 offset = new Vector3(0, 0, 0);    // Offset from the player

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        if (player != null)
        {
            target = player.transform;  // Set the target to the player's transform
        }
    }

     // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            smoothedPosition.z -= 5;
            transform.position = smoothedPosition;
        }
    }
}
