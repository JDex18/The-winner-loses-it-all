using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTarget3 : MonoBehaviour
{
    public GameObject player;
    public Controller controller;

    public GameObject icon;
    public GameObject collider;

    // Start is called before the first frame update
    void Start()
    {
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
                icon.SetActive(false);
                collider.SetActive(false);

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
