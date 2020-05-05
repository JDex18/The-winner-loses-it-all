using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMinigame3 : MonoBehaviour
{
    public Sprite image2;
    public Sprite image1;
    public Sprite imageYa;


    public GameObject instructions;
    public Image cuenta;

    private bool start;
    private float timer;


    public CreateCards createCards;
    private bool playing;

    public PauseButtonsController pauseButtonsController;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        timer = 0f;
        playing = false;
        instructions.SetActive(true);
        //pauseButtonsController.deactivatePauseMenu();

    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                start = true;
                instructions.SetActive(false);
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
                Invoke("canPause", 4f);
            }
        }
    }

    private void canPause()
    {
        pauseButtonsController.activatePauseMenu();
    }
}
