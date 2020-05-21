﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGood : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidbody;
    public Minigame4Manager minigameManager;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));

        minigameManager = GameObject.Find("GameManager").GetComponent<Minigame4Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector3(0f, -1f, 0) * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerDestroy")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            minigameManager.increaseHealth();
            Destroy(gameObject);
        }
    }
}
