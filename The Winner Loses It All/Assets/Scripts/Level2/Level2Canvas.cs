using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Canvas : MonoBehaviour
{
    public GameObject instructions;
    private float timerTitle;
    private bool start;
    public GameObject title;

    private float timer;

    string[] dialogue = new string[2];
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
            if (!PlayerMovementLevel2.play && start)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    instructions.SetActive(false);
                    PlayerMovementLevel2.play = true;
                    pauseButtonsController.activatePauseMenu();
                }
            }
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
            if (i != dialogue.Length)
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
            if (timer >= 1f)
            {
                SceneManager.LoadScene("SecondMinigame");
            }
        }
    }

    public void finish()
    {
        end = true;
        endDialogue.SetActive(true);
        PlayerMovementLevel2.play = false;
        timer = 0;//PARA ASEGURARSE DE QUE ESTÁ A CERO Y VOLVER A USARLO PARA TERMINAR EL NIVEL
    }
}
