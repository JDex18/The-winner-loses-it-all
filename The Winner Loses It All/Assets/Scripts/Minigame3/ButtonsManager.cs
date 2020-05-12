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

    [Range(0.1f, 2f)]
    public float speed;

    private int i;
    private int i2;

    // Start is called before the first frame update
    void Start()
    {
        completeRandomList();
        playerTurn = false;
        computerTurn = true;
        i = 0;
        i2 = 0;
        Invoke("ComputerTurn", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void completeRandomList()
    {
        for(int i = 0; i < 100; i++)//al haber diez turnos, con 100 habrá suficientes. Pero si usamos más turnos, entonces habrá que aumentar el número
        {
            randomList.Add(Random.Range(0, 4));
        }

        listCompleted = true;
    }

    public void changeTurn()
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
            i2 = i;
            Invoke("ComputerTurn", 2f);
        }
    }

    void ComputerTurn()
    {
        if(listCompleted && computerTurn)
        {
            buttons[randomList[i]].enableButton(); //si cambiamos i por count, funcionará como el juego tradicional de simon dice (el patrón se va sumando)

            if (count >= level)
            {
                level++;
                changeTurn();
            }

            else
            {
                count++;
            }

            i++;

            Invoke("ComputerTurn", speed);
        }
    }

    public void playerClick(int numButton)
    {
        if(numButton != randomList[i2 + playerCount])//si vas a hacerlo como el original, quita la i2
        {
            Debug.Log("FALLO");
            playerTurn = false;
            return;
        }

        if(playerCount == count)
        {
            Debug.Log("ACIERTO");
            changeTurn();
        }

        else
        {
            playerCount++;
        }
    }
}
