﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMinigame1 : MonoBehaviour
{
    public Sprite image2;
    public Sprite image1;
    public Sprite imageYa;


    public GameObject instructions;
    //public GameObject contador;
    public Image cuenta;

    private bool start;
    private float timer;

    public static bool fail;
    public static bool good;
    public Image textoCentral;
    public Sprite failImage;
    public Sprite goodImage1;
    public Sprite goodImage2;
    public Sprite goodImage3;
    public Sprite winImage;

    private bool win;
    public GameObject endPanel;

    public PauseButtonsController pauseButtonsController;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        timer = 0f;

        fail = false;
        good = false;

        win = false;
        endPanel.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Ambiente");
    }

    // Update is called once per frame
    void Update()
    {
        if(fail || good)
        {
            /*textoCentral.gameObject.SetActive(true);
            checkState();*/
            timer += Time.deltaTime;

            if(timer >= 2f)
            {
                timer = 0;
                textoCentral.gameObject.SetActive(false);
                fail = false;
                good = false;

                if (win)
                {
                    endPanel.SetActive(true);
                }
            }
            
        }

        if (!PlayerMovement22.play && !win)
        {
            if (!start)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    start = true;
                    instructions.SetActive(false);
                    cuenta.gameObject.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("Intro");
                }
            }

            else
            {
                timer += Time.deltaTime;

                if (timer >= 1f && timer < 2f)
                {
                    cuenta.sprite = image2;
                }

                else if (timer >= 2f && timer < 3f)
                {
                    cuenta.sprite = image1;
                }

                else if (timer >= 3f && timer < 4f)
                {
                    cuenta.sprite = imageYa;
                }

                else if (timer >= 4f)
                {
                    cuenta.gameObject.SetActive(false);
                    timer = 0;
                    PlayerMovement22.play = true;
                    pauseButtonsController.activatePauseMenu();
                }
            }
        }       
    }

    /*private void checkState()
    {
        if (fail)
        {
            textoCentral.sprite = failImage;
        }

        if (good)
        {
            if(Minigame1Manager.targetCount == 4)
            {
                textoCentral.sprite = winImage;
                PlayerMovement22.play = false;
                win = true;
            }

            else
            {
                textoCentral.sprite = goodImage;
            }
        }
    }*/

    public void wrong()
    {
        textoCentral.sprite = failImage;
        textoCentral.gameObject.SetActive(true);
        fail = true;
    }

    public void correct()
    {
        if (Minigame1Manager.targetCount == 4)
        {
            textoCentral.sprite = winImage;
            PlayerMovement22.play = false;
            win = true;
        }

        else
        {
            switch (Minigame1Manager.targetCount)
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
        }
        textoCentral.gameObject.SetActive(true);
        good = true;
    }
}
