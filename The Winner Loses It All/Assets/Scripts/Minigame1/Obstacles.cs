using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float speed;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerDestroy")
        {
            Destroy(gameObject);
        }
    }
}
