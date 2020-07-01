using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement22 : MonoBehaviour
{
    private float cooldown;
    private bool isCoolingDown;

    private float horizontalMove;
    private float verticalMove;

    private Animator anim;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private bool fail;
    Coroutine coroutine;

    private bool limit1;
    private bool limit2;
    private bool limit3;
    private bool limit4;

    Vector3 start;
    Vector3 end;
    float timer;

    public static bool play;

    private float timer2;
    private bool canMove;

    public CanvasMinigame1 canvasMinigame;

    public bool overCard;
    private GameObject card;

    Rigidbody rigidbody;
    private bool inPlattforms;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0.5f;
        isCoolingDown = false;
        anim = GetComponent<Animator>();

        startPosition = transform.position;
        startRotation = transform.rotation;
        fail = false;

        limit1 = false;
        limit2 = false;
        limit3 = false;
        limit4 = false;

        timer = 0f;

        play = false;

        timer = 0;
        canMove = true;

        rigidbody = GetComponent<Rigidbody>();
        inPlattforms = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            if (!canMove)
            {
                timer2 += Time.deltaTime;
                if(timer2 >= 0.7f /*&& Mathf.Abs(Input.GetAxis("Horizontal")) == 0 && Mathf.Abs(Input.GetAxis("Vertical")) == 0*/) //PARA QUE NO PUEDAS MANTENER PULSADO
                {
                    timer2 = 0;
                    canMove = true;
                }
            }
            if (fail)
            {
                fail = false;
                //StopCoroutine(coroutine);
                anim.SetBool("isJumping", false);
                transform.position = startPosition;
                transform.rotation = startRotation;
                isCoolingDown = false;
                inPlattforms = false;
                transform.parent = null;
                FindObjectOfType<AudioManager>().Play("Fallo");
            }

            if (isCoolingDown)
            {
                if (timer < 1f)
                {
                    transform.position = Vector3.Lerp(start, end, timer);
                    timer += Time.deltaTime / cooldown;
                }

                else
                {
                    transform.position = end;
                    isCoolingDown = false;
                    anim.SetBool("isJumping", false);
                }
            }

            else if(!isCoolingDown && canMove )
            {
                if(inPlattforms && !overCard)
                {
                    return;
                }
                horizontalMove = Input.GetAxis("Horizontal");
                verticalMove = Input.GetAxis("Vertical");

                if (Mathf.Abs(verticalMove) > 0)
                {
                    if (verticalMove < 0 && limit1)
                    {
                        return;
                    }

                    if (verticalMove > 0 && limit4)
                    {
                        return;
                    }

                    if (verticalMove > 0)
                    {
                        transform.rotation = Quaternion.identity;
                    }

                    else
                    {
                        transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.Sign(verticalMove) * 180, 0));
                    }

                    //coroutine = StartCoroutine(Move(new Vector3(0, 0, Mathf.Sign(verticalMove) * 4)));
                    Move(new Vector3(0, 0, Mathf.Sign(verticalMove) * 4));
                    canMove = false;
                }

                else if (Mathf.Abs(horizontalMove) > 0 && !inPlattforms)
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
                    //coroutine = StartCoroutine(Move(new Vector3(Mathf.Sign(horizontalMove) * 4, 0, 0)));
                    Move(new Vector3(Mathf.Sign(horizontalMove) * 4, 0, 0));
                    canMove = false;
                }
            }
        }

        else
        {
            anim.SetBool("isJumping", false);
        }
        

    }

    /*private IEnumerator Move(Vector3 target)
    {
        anim.SetBool("isJumping", true);
        isCoolingDown = true;
        Vector3 start = transform.position;
        Vector3 end = start + target;
        float timer = 0f;

        while (timer < 1f)
        {
            transform.position = Vector3.Lerp(start, end, timer);
            timer += Time.deltaTime / cooldown;
            yield return null;
        }

        transform.position = end;
        isCoolingDown = false;
        anim.SetBool("isJumping", false);

    }*/

    private void Move(Vector3 target)
    {
        anim.SetBool("isJumping", true);
        isCoolingDown = true;
        start = transform.position;
        end = start + target;
        timer = 0f;
        FindObjectOfType<AudioManager>().Play("Salto");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            //transform.position = startPosition;
            fail = true;
            canvasMinigame.wrong();
        }

        if (other.tag == "Card")
        {
            overCard = true;
            card = other.gameObject;
            transform.parent = card.transform;
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
        }

        if (other.tag == "inPlattforms")
        {
            inPlattforms = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "LimitCollider")
        {
            limit1 = true;
        }

        if (other.tag == "LimitCollider2")
        {
            limit2 = true;
        }

        if (other.tag == "LimitCollider3")
        {
            limit3 = true;
        }

        if (other.tag == "LimitCollider4")
        {
            limit4 = true;
        }

        if (other.tag == "Finish")
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LimitCollider")
        {
            limit1 = false;
        }

        if (other.tag == "LimitCollider2")
        {
            limit2 = false;
        }

        if (other.tag == "LimitCollider3")
        {
            limit3 = false;
        }

        if (other.tag == "LimitCollider4")
        {
            limit4 = false;
        }

        if (other.tag == "Card")
        {
            overCard = false;
            card = null;
            transform.parent = null;
            rigidbody.useGravity = true;
            rigidbody.isKinematic = false;
            transform.localScale = new Vector3(0.1967f, 0.1967f, 0.1967f);
        }

        if (other.tag == "inPlattforms")
        {
            inPlattforms = false;
        }
    }
}
