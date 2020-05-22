using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMinigame4 : MonoBehaviour
{
    private float cooldown;
    private bool isCoolingDown;

    private float horizontalMove;
    private float verticalMove;

    private Animator anim;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private bool fail;

    private bool limit2;
    private bool limit3;

    Vector3 start;
    Vector3 end;
    float timer;

    public static bool play;

    private float timer2;
    private bool canMove;

    //public CanvasMinigame1 canvasMinigame;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 1f;//originalmente 0.5f, y depués a 2f
        isCoolingDown = false;
        anim = GetComponent<Animator>();

        startPosition = transform.position;
        startRotation = transform.rotation;
        fail = false;

        limit2 = false;
        limit3 = false;

        timer = 0f;

        play = false;

        timer = 0;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            if (!canMove)//para que el  jugador no pueda volver a darle hasta que termine el movimiento
            {
                timer2 += Time.deltaTime;
                if (timer2 >= 0.8f)
                {
                    timer2 = 0;
                    canMove = true;
                }
            }
            /*if (fail)
            {
                fail = false;
                //StopCoroutine(coroutine);
                anim.SetBool("isJumping", false);
                transform.position = startPosition;
                transform.rotation = startRotation;
                isCoolingDown = false;
            }*/

            if (isCoolingDown)
            {
                if (timer < 1f)//originalmente 1f
                {
                    transform.position = Vector3.Lerp(start, end, timer);
                    timer += Time.deltaTime / cooldown;
                }

                else
                {
                    transform.position = end;
                    isCoolingDown = false;
                    anim.SetBool("isWalking", false);
                }
            }

            else if (!isCoolingDown && canMove)
            {
                horizontalMove = Input.GetAxis("Horizontal");
                
                if (Mathf.Abs(horizontalMove) > 0)
                {
                    if (horizontalMove > 0 && limit2)
                    {
                        return;
                    }

                    if (horizontalMove < 0 && limit3)
                    {
                        return;
                    }

                    transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.Sign(horizontalMove) * 90, 0));
                    Move(new Vector3(Mathf.Sign(horizontalMove) * 6, 0, 0));
                    canMove = false;
                }
            }
        }

        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    private void Move(Vector3 target)
    {
        anim.SetBool("isWalking", true);
        isCoolingDown = true;
        start = transform.position;
        end = start + target;
        timer = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.tag == "Obstacle")
        {
            //transform.position = startPosition;
            fail = true;
            canvasMinigame.wrong();
        }*/
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "LimitCollider2")
        {
            limit2 = true;
        }

        if (other.tag == "LimitCollider3")
        {
            limit3 = true;
        }


        /*if (other.tag == "Finish")
        {
            transform.position = startPosition;
            //other.gameObject.SetActive(false);
            canvasMinigame.correct();
        }

        if (other.tag == "Obstacle")
        {
            //transform.position = startPosition;
            fail = true;
            canvasMinigame.wrong();
        }*/
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "LimitCollider2")
        {
            limit2 = false;
        }

        if (other.tag == "LimitCollider3")
        {
            limit3 = false;
        }

    }

    public void resetPlayer()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
