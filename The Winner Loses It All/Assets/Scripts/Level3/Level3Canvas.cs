using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3Canvas : MonoBehaviour
{
    public GameObject instructions;
    private float timerTitle;
    private bool start;
    public GameObject title;

    private float timer;

    string[] dialogue = new string[6];
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
        PlayerPrefs.SetInt("Level3", 1);
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
        dialogue[0] = "Iker: Eyy Toni, que tal?";
        dialogue[1] = "Toni: Ahh hola Iker. Venía a por un café. Tu que tal estás?";
        dialogue[2] = "Iker: Bien tío. Oye lo del partido de hoy es una apuesta segura. Te animas y ganamos una pasta?";
        dialogue[3] = "Toni: No sé Iker, creo que mejor no...";
        dialogue[4] = "Iker: Venga Toni no te eches atrás. Al salir del curro vamos tu y yo a la casa de apuestas y nos la jugamos, como en los viejos tiempo.";
        dialogue[5] = "Toni: No debería...";
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
                FindObjectOfType<AudioManager>().Play("Outro");
            }
        }

        else if (!endDialogue.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                SceneManager.LoadScene("ThirdMinigame");
            }
        }
    }

    public void finish()
    {
        end = true;
        endDialogue.SetActive(true);
        //PlayerMovementLevel2.play = false;
        timer = 0;//PARA ASEGURARSE DE QUE ESTÁ A CERO Y VOLVER A USARLO PARA TERMINAR EL NIVEL
    }
}
