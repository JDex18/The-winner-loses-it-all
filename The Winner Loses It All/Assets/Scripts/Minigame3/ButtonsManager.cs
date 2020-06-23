using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public Button[] buttons;
    public List<int> randomList = new List<int>();

    private bool listCompleted;
    public bool playerTurn;
    public bool computerTurn;

    private int count;
    private int playerCount;
    private int level;
    public int round;

    [Range(0.1f, 2f)]
    public float speed;

    public CanvasMinigame3 canvasMinigame;
    //private int i;
    //private int i2;

    [Header("Numbers")]
    public Image countImage;
    public Sprite image0;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public Sprite image5;
    public Sprite image6;

    // Start is called before the first frame update
    void Start()
    {
        completeRandomList();
        playerTurn = false;
        computerTurn = true;
        //i = 0;
        //i2 = 0;
        round = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void completeRandomList()
    {
        for(int i = 0; i < 10; i++)//al haber diez turnos, con 100 habrá suficientes. Pero si usamos más turnos, entonces habrá que aumentar el número
        {
            int color = Random.Range(0, 4);

            if(i >= 2)//para que no haga más de dos colores seguidos
            {
                while(color == randomList[i-2] && color == randomList[i - 1])
                {
                    color = Random.Range(0, 4);
                }
            }

            randomList.Add(color);
        }

        listCompleted = true;
    }

    private void changeTurn()
    {
        if (computerTurn)
        {
            computerTurn = false;
            playerTurn = true;
        }

        else
        {
            playerTurn = false;
            computerTurn = true;
            count = 0;
            playerCount = 0;
            //i2 = i;
            Invoke("ComputerTurn", 2f);
        }
    }

    void ComputerTurn()
    {
        if(listCompleted && computerTurn)
        {
            buttons[randomList[count]].enableButton(); //si cambiamos i por count, funcionará como el juego tradicional de simon dice (el patrón se va sumando)

            if (count >= level)
            {
                level++;
                changeTurn();
            }

            else
            {
                count++;
            }

            //i++;

            Invoke("ComputerTurn", speed);
        }
    }

    public void playerClick(int numButton)
    {
        if(numButton != randomList[playerCount])//si vas a hacerlo como el original, quita la i2
        {
            Debug.Log("FALLO");
            canvasMinigame.wrongButton();
            countImage.sprite = image0;
            resetGame();
            FindObjectOfType<AudioManager>().Play("Fallo2");
            return;
        }

        if(playerCount == count)
        {
            Debug.Log("ACIERTO");
            if(count == 5)
            {
                countImage.sprite = image6;
                round++;
                if(round == 3)
                {
                    canvasMinigame.winGame();
                    FindObjectOfType<AudioManager>().Play("Victoria");
                }

                else
                {
                    canvasMinigame.roundCompleted();
                    resetGame();
                    FindObjectOfType<AudioManager>().Play("Acierto");
                }
            }

            else
            {
                switch (level)
                {
                    case 1:
                        countImage.sprite = image1;
                        break;
                    case 2:
                        countImage.sprite = image2;
                        break;
                    case 3:
                        countImage.sprite = image3;
                        break;
                    case 4:
                        countImage.sprite = image4;
                        break;
                    case 5:
                        countImage.sprite = image5;
                        break;
                }
                FindObjectOfType<AudioManager>().Play("Acierto2");
                changeTurn();
            }
        }

        else
        {
            playerCount++;
        }
    }

    private void resetGame()
    {
        playerTurn = false;
        count = 0;
        playerCount = 0;
        level = 0;
        randomList.Clear();
        completeRandomList();
        computerTurn = true;

        switch (round)
        {
            case 1:
                speed = 0.6f;//0.9f antes
                break;
            case 2:
                speed = 0.3f;//0.6f antes
                break;
            /*case 3:
                speed = 0.3f;
                break;*/
        }

    }

    public void startGame()
    {
        countImage.sprite = image0;
        Invoke("ComputerTurn", 2f);
    }
}
