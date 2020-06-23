using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject player;
    public GameObject panel;
    public Controller controller;
    public Text texto;

    private Animator anim;
    public int personaje;//SIRVE PARA INDICAR QUE PERSONAJE ES Y PODER ACCEDER A SUS RESPECTIVAS FRASES, LAS CUALES SE ENCUENTRAN EN ESA POSICIÓN DE LA LISTA
    private int i;//ES UN INDEX QUE PERMITE MOVERSE DE UNA FRASE A OTRA DEL ARRAY

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= 4 && Input.GetKeyDown(KeyCode.Space))
        {
            if (!PauseButtonsController.paused)
            {
                if (i == 0) //CUANDO LA CONVERSACIÓN EMPIECE, LANZARÁ LA PRIMERA FRASE
                {
                    FindObjectOfType<AudioManager>().Play("Dialogo");
                    activarDialogo();
                }

                else if (i == controller.dialogosDePersonajes[personaje].Length) //CUANDO SE HAYAN MOSTRADO TODAS LAS FRASES, SALDRÁ DE LA CONVERSACIÓN
                {
                    desactivarDialogo();
                }

                else //MIENTRAS QUEDEN FRASES, PASARÁ A LA SIGUIENTE AL PULSAR ESPACIO
                {
                    texto.text = controller.dialogosDePersonajes[personaje][i];
                    i++;
                }
            }
                  
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "Icono")
                    child.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "Icono")
                    child.gameObject.SetActive(false);
            }
        }
    }

    private void activarDialogo()
    {
        texto.text = controller.dialogosDePersonajes[personaje][0];

        controller.enConversacion = true;
        transform.LookAt(player.transform);
        player.transform.LookAt(transform);
        panel.SetActive(true);
        anim.SetBool("isTalking", true);

        foreach (Transform child in transform)
        {
            if (child.tag == "Icono")
                child.gameObject.SetActive(false);
        }

        i++;
    }

    private void desactivarDialogo()
    {
        i = 0;
        controller.enConversacion = false;
        panel.SetActive(false);
        anim.SetBool("isTalking", false);

        foreach (Transform child in transform)
        {
            if (child.tag == "Icono")
                child.gameObject.SetActive(true);
        }
    }
}
