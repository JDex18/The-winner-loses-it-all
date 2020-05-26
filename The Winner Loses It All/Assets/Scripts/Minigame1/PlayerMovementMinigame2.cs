using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMinigame2 : MonoBehaviour
{
    private float speed;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool jumping;

    private float startTime;
    private float time;
    Animator anim;

    public bool overCard;
    private GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (jumping)
        {
            time = (Time.time - startTime) * speed;
            transform.position = Vector3.Lerp(startPos, targetPos, time);

            if(transform.position == targetPos)
            {
                jumping = false;
                anim.SetBool("isJumping", false);
            }
        }

        if(!jumping)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                targetPos = transform.position + new Vector3(0, 0, 4);
                transform.rotation = Quaternion.Euler(0, 0, 0);

                anim.SetBool("isJumping", true);
                startTime = Time.time;
                startPos = transform.position;
                jumping = true;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                targetPos = transform.position + new Vector3(0, 0, -4);
                transform.rotation = Quaternion.Euler(0, 180, 0);

                anim.SetBool("isJumping", true);
                startTime = Time.time;
                startPos = transform.position;
                jumping = true;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                targetPos = transform.position + new Vector3(-4, 0, 0);
                transform.rotation = Quaternion.Euler(0, -90, 0);

                anim.SetBool("isJumping", true);
                startTime = Time.time;
                startPos = transform.position;
                jumping = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                targetPos = transform.position + new Vector3(4, 0, 0);
                transform.rotation = Quaternion.Euler(0, 90, 0);

                anim.SetBool("isJumping", true);
                startTime = Time.time;
                startPos = transform.position;
                jumping = true;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Card")
        {
            overCard = true;
            card = other.gameObject;
            transform.parent = card.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Card")
        {
            overCard = false;
            card = null;
            transform.parent = null;
        }
    }
}
