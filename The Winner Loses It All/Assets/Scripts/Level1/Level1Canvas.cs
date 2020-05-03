using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1Canvas : MonoBehaviour
{
    public GameObject instructions;
    private float timerTitle;
    private bool start;
    public GameObject title;

    public GameObject arrows;
    private bool showingArrows;
    private float timer;

    public Controller controller;

    string[] dialogue = new string[2];
    private bool end;
    public GameObject endDialogue;
    public GameObject finalPanel;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        instructions.SetActive(true);
        timerTitle = 0f;
        start = false;
        title.SetActive(true);

        arrows.SetActive(false);
        showingArrows = false;
        timer = 0f;

        completeDialogue();
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            endLevel();
        }

        else
        {
            if (!start)//PARA ANIMAR EL TITULO DEL NIVEL
            {
                timerTitle += Time.deltaTime;
                if (timerTitle >= 5.20f)
                {
                    timerTitle = 0f;
                    start = true;
                    title.SetActive(false);
                }
            }
            if (!PlayerMovement.play && start)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    instructions.SetActive(false);
                    PlayerMovement.play = true;
                }
            }

            if (!showingArrows)
            {
                checkClue();
            }

            else
            {
                timer += Time.deltaTime;
                if (timer >= 5.1f)
                {
                    showingArrows = false;
                    arrows.SetActive(false);
                    timer = 0;
                }
            }
        }
        
    }

    private void checkClue()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !controller.enConversacion && PlayerMovement.play)
        {
            arrows.SetActive(true);
            showingArrows = true;
        }
    }

    private void completeDialogue()
    {
        dialogue[0] = "Toni: Vamos Toni, concentrate";
        dialogue[1] = "Toni: Solo tienes que pasar por delante, ignorarla e ir a trabajar como si no ocurriera nada y...";
    }

    private void endLevel()
    {
        if (Input.GetKeyDown(KeyCode.Space) && endDialogue.activeSelf)
        {
            if(i != dialogue.Length)
            {
                endDialogue.GetComponentInChildren<Text>().text = dialogue[i];
                i++;
            }

            else
            {
                endDialogue.SetActive(false);
                finalPanel.SetActive(true);
            }            
        }

        else if (!endDialogue.activeSelf)
        {
            timer += Time.deltaTime;
            if(timer >= 1f)
            {
                SceneManager.LoadScene("FirstMinigame");
            }
        }
    }

    public void finish()
    {
        end = true;
        endDialogue.SetActive(true);
        PlayerMovement.play = false;
        timer = 0;//PARA ASEGURARSE DE QUE ESTÁ A CERO Y VOLVER A USARLO PARA TERMINAR EL NIVEL
    }

}
