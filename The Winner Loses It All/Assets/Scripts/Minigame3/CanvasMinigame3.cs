using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasMinigame3 : MonoBehaviour
{
    public Sprite image3;
    public Sprite image2;
    public Sprite image1;
    public Sprite imageYa;


    public GameObject instructions;
    public Image cuenta;

    private bool start;
    private float timer;
    private bool playing;

    public Image textoCentral;
    public static bool fail;
    public static bool good;
    public Sprite failImage;
    public Sprite goodImage1;
    public Sprite goodImage2;
    public Sprite goodImage3;

    private bool win;
    public Sprite winImage;
    public GameObject endPanel;
    public PauseButtonsController pauseButtonsController;

    public ButtonsManager buttonsManager;
    public Text instructionsText;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        timer = 0f;
        playing = false;
        instructions.SetActive(true);
        textoCentral.gameObject.SetActive(false);

        win = false;
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            timer += Time.deltaTime;

            if (timer >= 2f)
            {
                timer = 0;
                textoCentral.gameObject.SetActive(false);
                endPanel.SetActive(true);
                Invoke("nextLevel", 1.5f);
            }

            return;
        }

        if (fail || good)
        {
            timer += Time.deltaTime;

            if (timer >= 2f)
            {
                timer = 0;
                textoCentral.gameObject.SetActive(false);

                if (fail)
                {
                    start = false;
                    playing = false;
                    instructionsText.text = "Si estás preparado, presiona Espacio";
                    instructions.SetActive(true);
                }

                if (good)
                {
                    buttonsManager.startGame();
                }
                fail = false;
                good = false;
            }
        }

        if (!start)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                start = true;
                instructions.SetActive(false);
                cuenta.sprite = image3;
                cuenta.gameObject.SetActive(true);
            }
        }

        else if (start && !playing)
        {
            timer += Time.deltaTime;

            if (timer >= 1f && timer <= 2f)
            {
                cuenta.sprite = image2;
            }

            else if (timer >= 2f && timer <= 3f)
            {
                cuenta.sprite = image1;
            }

            else if (timer >= 3f && timer <= 4f)
            {
                cuenta.sprite = imageYa;
            }

            else if (timer >= 4f)
            {
                cuenta.gameObject.SetActive(false);
                timer = 0;
                buttonsManager.startGame();
                playing = true;
                pauseButtonsController.activatePauseMenu();
            }
        }
    }

    public void wrongButton()
    {
        textoCentral.sprite = failImage;
        textoCentral.gameObject.SetActive(true);
        fail = true;
    }

    public void roundCompleted()
    {
        switch (buttonsManager.round)
        {
            case 1:
                textoCentral.sprite = goodImage1;
                break;
            case 2:
                textoCentral.sprite = goodImage2;
                break;
            case 3:
                textoCentral.sprite = goodImage3;
                break;
        }
        
        textoCentral.gameObject.SetActive(true);
        good = true;
    }

    public void winGame()
    {
        win = true;
        textoCentral.sprite = winImage;
        textoCentral.gameObject.SetActive(true);
    }

    private void nextLevel()
    {
        SceneManager.LoadScene("Level4");
    }
}
