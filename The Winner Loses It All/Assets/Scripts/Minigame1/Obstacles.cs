using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidbody;
    public bool right;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        if(transform.position.x < 172)
        {
            right = true;
        }

        else
        {
            right = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            rigidbody.velocity = new Vector3(1f, 0, 0) * speed;
        }

        else
        {
            rigidbody.velocity = new Vector3(-1f, 0, 0) * speed;
        }
        //rigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerDestroy")
        {
            Destroy(gameObject);
        }
    }

}
