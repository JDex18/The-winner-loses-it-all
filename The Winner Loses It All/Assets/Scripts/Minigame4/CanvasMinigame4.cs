using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasMinigame4 : MonoBehaviour
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
    public static bool lose;
    public static bool win;
    public Sprite loseImage;
    public Sprite winImage;

    public GameObject endPanel;
    public PauseButtonsController pauseButtonsController;
    public Text instructionsText;

    public Minigame4Manager minigameManager;
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        timer = 0f;
        playing = false;
        instructions.SetActive(true);
        textoCentral.gameObject.SetActive(false);

        win = false;
        lose = false;
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

        if (lose)
        {
            timer += Time.deltaTime;

            if (timer >= 2f)
            {
                timer = 0;
                textoCentral.gameObject.SetActive(false);
                start = false;
                playing = false;
                instructionsText.text = "Si estás preparado, presiona Espacio";
                instructions.SetActive(true);
                lose = false;
                PlayerMovementMinigame4.play = false;
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
                PlayerMovementMinigame4.play = true;
                minigameManager.startTimer();
                playing = true;
                pauseButtonsController.activatePauseMenu();
            }
        }

    }

    public void winGame()
    {
        win = true;
        textoCentral.sprite = winImage;
        textoCentral.gameObject.SetActive(true);
        PlayerMovementMinigame4.play = false;
    }

    private void nextLevel()
    {
        SceneManager.LoadScene("Level4");
    }
}
