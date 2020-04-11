using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public Transform player;
    private Vector3 cameraOffset;



    [Range(0.01f, 1.0f)]
    public float smoothFactor;//para suavizar el movimiento de la cámara
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.position;
    }

    // Update is called once per frame
    private void Update()
    {


    }

    void LateUpdate()
    {
        Vector3 newPos = cameraOffset + player.position;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    }
}
