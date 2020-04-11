using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    private float cooldown;
    private bool isCoolingDown;

    private float horizontalMove;
    private float verticalMove;

    private Animator anim;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0.5f;
        isCoolingDown = false;
        anim = GetComponent<Animator>();

        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCoolingDown)
        {
            return;
        }

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if(Mathf.Abs(verticalMove) > 0)
        {
            if(verticalMove > 0)
            {
                transform.rotation = Quaternion.identity;
            }

            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.Sign(verticalMove) * 180, 0));
            }

            StartCoroutine(Move(new Vector3(0, 0, Mathf.Sign(verticalMove) * 4)));
        }

        else if (Mathf.Abs(horizontalMove) > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.Sign(horizontalMove) * 90, 0));
            StartCoroutine(Move(new Vector3(Mathf.Sign(horizontalMove) * 4, 0, 0)));
        }
    }

    private IEnumerator Move(Vector3 target)
    {
        anim.SetBool("isJumping", true);
        isCoolingDown = true;
        Vector3 start = transform.position;
        Vector3 end = start + target;
        float timer = 0f;

        while(timer < 1f)
        {
            transform.position = Vector3.Lerp(start, end, timer);
            timer += Time.deltaTime / cooldown;
            yield return null;
        }

        transform.position = end;
        isCoolingDown = false;
        anim.SetBool("isJumping", false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            transform.position = startPosition;
        }
    }
}
