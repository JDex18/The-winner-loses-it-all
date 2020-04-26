using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingSimple : MonoBehaviour
{
    public Transform player;
    private Vector3 cameraOffset;

    private float transitionSpeed;

    [Range(0.01f, 1.0f)]
    public float smoothFactor;//para suavizar el movimiento de la cámara
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.position;
        transitionSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 newPos = cameraOffset + player.position;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    }
}
