using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTarget : MonoBehaviour
{
    public GameObject player;
    public Controller controller;

    private Animator anim;
    public Level2Canvas levelCanvas;
    public GameObject icon;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        icon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 4 && Input.GetKeyDown(KeyCode.Space) && !controller.enConversacion)
        {
            if (!PauseButtonsController.paused)
            {
                controller.enConversacion = true;
                transform.LookAt(player.transform);
                player.transform.LookAt(transform);
                anim.SetBool("isTalking", true);
                controller.enConversacion = true;
                icon.SetActive(false);

                levelCanvas.finish();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            icon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            icon.SetActive(false);
        }
    }
}
