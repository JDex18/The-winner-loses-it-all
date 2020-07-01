using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles : MonoBehaviour
{

    private float speed;
    private bool passed;
    public Controller controller;
    private bool stop;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        passed = false;
        rigidbody = GetComponent<Rigidbody>();
        if (controller.soundEffects)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.soundEffects)
        {
            if (PauseButtonsController.paused)
            {
                GetComponent<AudioSource>().Pause();
            }

            else
            {
                GetComponent<AudioSource>().UnPause();
                
            }
        }

        if (!stop || passed)
        {
            //transform.position += new Vector3(0, 0, -2f * Time.deltaTime * speed);
            rigidbody.velocity = transform.forward * speed;
        }

        else
        {
            rigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TriggerDestroy")
        {
            Destroy(gameObject);
        }

        if (other.tag == "TriggerCoches")
        {
            passed = true;
        }

        if (other.tag == "Car")
        {
            stop = true;
        }

        if (other.tag == "TriggerStop")
        {
            if (controller.enPaso)
            {
                stop = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Car")
        {
            stop = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "TriggerStop")
        {
            if (!controller.enPaso)
            {
                stop = false;
            }           
        }
    }
}
