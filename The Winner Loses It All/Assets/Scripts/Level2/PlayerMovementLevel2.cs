using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLevel2 : MonoBehaviour
{
    private float playerSpeed;
    private float horizontalMove;
    private float verticalMove;

    private CharacterController player;
    private Animator anim;
    private Vector3 playerInput;

    public Camera cam;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;

    public Controller controller;
    private float gravity;

    public static bool play;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 3f;
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        controller.enConversacion = false;
        gravity = 9.8f;
        play = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            walk();
        }
    }

    void walk()
    {
        if (!controller.enConversacion) //SI ESTÁ EN UNA CONVERSACIÓN NO PODRÁ MOVERSE
        {
            horizontalMove = Input.GetAxis("Horizontal");
            verticalMove = Input.GetAxis("Vertical");

            playerInput = new Vector3(horizontalMove, 0f, verticalMove);
            playerInput = Vector3.ClampMagnitude(playerInput, 1);

            camDirection();
            movePlayer = playerInput.x * camRight + playerInput.z * camForward;

            movePlayer *= playerSpeed;

            player.transform.LookAt(player.transform.position + movePlayer);

            SetGravity();

            player.Move(movePlayer * Time.deltaTime);

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                anim.SetBool("isWalking", true);
            }

            else
            {
                anim.SetBool("isWalking", false);
            }
        }

        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void camDirection()
    {
        camForward = cam.transform.forward;
        camRight = cam.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void SetGravity()
    {
        movePlayer.y = -gravity;
    }

    public void playFootstepSound()
    {
        if (controller.soundEffects)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
