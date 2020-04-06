using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    private Vector3 cameraOffset;
    private Vector3 cameraOffset1;
    private Vector3 cameraOffset2;
    private Vector3 cameraOffset3;

    public Transform cam2;
    public Transform cam3;
    public Transform object2;
    public Transform object3;

    public Transform[] views;
    private Transform currentView;
    private float transitionSpeed;
    public bool cameraTransition;
    public static bool cambio1;
    public static bool cambio2;
    public static bool cambio3;


    [Range(0.01f, 1.0f)]
    public float smoothFactor;//para suavizar el movimiento de la cámara
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset1 = transform.position - player.position;
        transitionSpeed = 2f;
        cameraTransition = false;
        currentView = views[0];

        //cam2 = new Vector3(39.44464f, -47.32929f, -83.11659f);
        cameraOffset2 = cam2.position - object2.position;
        cameraOffset3 = cam3.position - object3.position;
        cameraOffset = cameraOffset1;
        cambio1 = false;
        cambio2 = false;
        cambio3 = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (cambio1 || cambio2 || cambio3)
        {
            cambioCamara();            
        }


    }

    void LateUpdate()
    {

        if (!cameraTransition)
        {
            Vector3 newPos = cameraOffset + player.position;

            transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);           
        }

        else
        {
            transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
            //transform.rotation = currentView.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, currentView.rotation, Time.deltaTime * 2);

            if (Vector3.Distance(transform.position, currentView.position) <= 5)
            {
                cameraTransition = false;
            }
        }
        
    }


    void cambioCamara()
    {

        if (cambio1)
        {
            cambio1 = false;

            if (cameraOffset == cameraOffset1)
            {
                currentView = views[0];
                cameraTransition = true;
                cameraOffset = cameraOffset2;
                return;
            }

            if (cameraOffset == cameraOffset2)
            {
                currentView = views[1];
                cameraTransition = true;
                cameraOffset = cameraOffset1;
                return;
            }
        }

        if (cambio2)
        {
            cambio2 = false;

            if (cameraOffset == cameraOffset1)
            {
                currentView = views[2];
                cameraTransition = true;
                cameraOffset = cameraOffset2;
                return;
            }

            if (cameraOffset == cameraOffset2)
            {
                currentView = views[3];
                cameraTransition = true;
                cameraOffset = cameraOffset1;
                return;
            }
        }

        if (cambio3)
        {
            cambio3 = false;

            if (cameraOffset == cameraOffset3)
            {
                currentView = views[4];
                cameraTransition = true;
                cameraOffset = cameraOffset2;
                return;
            }

            if (cameraOffset == cameraOffset2)
            {
                currentView = views[5];
                cameraTransition = true;
                cameraOffset = cameraOffset3;
                return;
            }
        }


    }
}
