using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject character;
    private float timer;
    private bool reached;
    // Start is called before the first frame update
    void Start()
    {
        character.SetActive(false);
        timer = 0f;
        reached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (reached)
        {
            timer += Time.deltaTime;

            if(timer >= 0.5)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            character.SetActive(true);
            reached = true;
        }
    }
}
