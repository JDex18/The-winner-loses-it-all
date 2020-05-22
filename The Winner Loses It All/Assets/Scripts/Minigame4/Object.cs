using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidbody;
    public Minigame4Manager minigameManager;
    public GameObject wrongEffect;

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
            minigameManager.loseHealth();
            Instantiate(wrongEffect, transform.position, wrongEffect.transform.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
