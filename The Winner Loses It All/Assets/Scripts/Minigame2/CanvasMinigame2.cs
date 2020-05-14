using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMinigame2 : MonoBehaviour
{
    public Sprite image3;
    public Sprite image2;
    public Sprite image1;
    public Sprite imageYa;


    public GameObject instructions;
    public Image cuenta;

    private bool start;
    private float timer;


    public CreateCards createCards;
    private bool playing;

    public Image textoCentral;
    public static bool fail;
    public static bool good;
    public Sprite failImage;
    public Sprite goodImage;

    public Sprite roundImage1;
    public Sprite roundImage2;

    private bool win;
    private bool lose;
    public Sprite winImage;
    public Sprite loseImage;
    public Image finalText;
    private float timer2;

    public GameObject endPanel;

    public PauseButtonsController pauseButtonsController;
    public Minigame2Manager minigameManager;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        timer = 0f;
        playing = false;
        instructions.SetActive(true);
        textoCentral.gameObject.SetActive(false);

        timer2 = 0f;
        win = false;
        lose = false;
        finalText.gameObject.SetActive(false);
        endPanel.SetActive(false);
        //pauseButtonsController.deactivatePauseMenu();

    }

    // Update is called once per frame
    void Update()
    {
        if(win || lose)
        {
            timer2 += Time.deltaTime;

            if (timer2 >= 2f)
            {
                timer2 = 0;
                finalText.gameObject.SetActive(false);

                if (win)
                {
                    if(Minigame2Manager.round == 3)
                    {
                        endPanel.SetActive(true);
                        Invoke("nextLevel", 1.5f);
                    }

                    else
                    {
                        win = false;
                        start = true;
                        playing = false;
                        cuenta.gameObject.SetActive(true);
                        cuenta.sprite = image3;
                        minigameManager.resetTime();
                        createCards.resetCards();
                        pauseButtonsController.deactivatePauseMenu();
                    }
                }

                if (lose)
                {
                    lose = false;
                    start = false;
                    playing = false;
                    instructions.SetActive(true);
                    minigameManager.resetTime();
                    createCards.resetCards();
                    pauseButtonsController.deactivatePauseMenu();
                }
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

        else if(start && !playing)
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
                createCards.create();
                playing = true;
                Invoke("canPause", 5f);
            }
        }
    }

    private void canPause()
    {
        pauseButtonsController.activatePauseMenu();
        minigameManager.startTimer();
    }

    public void wrongCards()
    {
        textoCentral.sprite = failImage;
        textoCentral.gameObject.SetActive(true);
        fail = true;
    }

    public void correctCards()
    {
        textoCentral.sprite = goodImage;
        textoCentral.gameObject.SetActive(true);
        good = true;
    }

    public void winGame()
    {
        win = true;
        finalText.sprite = winImage;
        finalText.gameObject.SetActive(true);
    }

    public void loseGame()
    {
        lose = true;
        finalText.sprite = loseImage;
        finalText.gameObject.SetActive(true);
    }

    private void nextLevel()
    {
        minigameManager.changeScene();
    }

    public void roundCompleted()
    {
        switch (Minigame2Manager.round)
        {
            case 1:
                finalText.sprite = roundImage1;
                break;
            case 2:
                finalText.sprite = roundImage2;
                break;
        }

        finalText.gameObject.SetActive(true);
        win = true;
    }
}
