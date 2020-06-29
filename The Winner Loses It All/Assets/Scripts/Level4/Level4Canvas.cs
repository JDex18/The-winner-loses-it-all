using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level4Canvas : MonoBehaviour
{
    public GameObject instructions;
    private float timerTitle;
    private bool start;
    public GameObject title;

    private float timer;

    string[] dialogue = new string[7];
    private bool end;
    public GameObject endDialogue;
    public GameObject finalPanel;
    private int i;
    public PauseButtonsController pauseButtonsController;
    // Start is called before the first frame update
    void Start()
    {
        instructions.SetActive(true);
        timerTitle = 0f;
        start = false;
        title.SetActive(true);

        timer = 0f;

        completeDialogue();
        i = 1;
        PlayerPrefs.SetInt("Level4", 1);
        FindObjectOfType<AudioManager>().Play("Ambiente");
        FindObjectOfType<AudioManager>().Play("Ambiente2");
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
            if (!PlayerMovementLevel2.play && start)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    instructions.SetActive(false);
                    PlayerMovementLevel2.play = true;
                    pauseButtonsController.activatePauseMenu();
                    FindObjectOfType<AudioManager>().Play("Intro");
                }
            }
        }

    }

    private void completeDialogue()
    {
        dialogue[0] = "Toni: Una máquina de apuestas?";
        dialogue[1] = "Toni: Si ayer hubiera apostado con Iker hubiera ganado...";
        dialogue[2] = "Toni: No, no puedo volver a caer en esto. Solo voy a empeorar la situación";
        dialogue[3] = "Toni: Bueno... pero si pongo poco dinero tampoco será para tanto. No?";
        dialogue[4] = "Toni: No Toni, piensa en Mónica y en Daniel. Esto no les hace ningún bien";
        dialogue[5] = "Toni: Solo aguanta...";
        dialogue[6] = "Toni: Cuanto tiempo más voy a tener que aguantar esto?";
    }

    private void endLevel()
    {
        if (Input.GetKeyDown(KeyCode.Space) && endDialogue.activeSelf)
        {
            if (i != dialogue.Length)
            {
                endDialogue.GetComponentInChildren<Text>().text = dialogue[i];
                i++;
            }

            else
            {
                endDialogue.SetActive(false);
                finalPanel.SetActive(true);
                FindObjectOfType<AudioManager>().parar("Ambiente");
                FindObjectOfType<AudioManager>().parar("Ambiente2");
                FindObjectOfType<AudioManager>().Play("Outro");
            }
        }

        else if (!endDialogue.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                SceneManager.LoadScene("FourthMinigame");
            }
        }
    }

    public void finish()
    {
        end = true;
        endDialogue.SetActive(true);
        //PlayerMovementLevel2.play = false;
        timer = 0;//PARA ASEGURARSE DE QUE ESTÁ A CERO Y VOLVER A USARLO PARA TERMINAR EL NIVEL
        FindObjectOfType<AudioManager>().Play("Dialogo");
    }
}
