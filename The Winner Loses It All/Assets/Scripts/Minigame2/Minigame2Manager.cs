using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Minigame2Manager : MonoBehaviour
{
    public Text time;
    private float timer;
    public static bool start;
    public CanvasMinigame2 canvasMinigame;
    public static int round;
    private float limitTime;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        start = false;
        time.gameObject.SetActive(false);
        round = 0;
        limitTime = 90f;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timer += Time.deltaTime;
            if(timer >= limitTime)
            {
                timer = limitTime;
                start = false;
                canvasMinigame.loseGame();
            }

            time.text = CalcularTiempo((int)limitTime - (int)timer);
        }
    }

    public void startTimer()
    {
        time.gameObject.SetActive(true);
        start = true;
        timer = 0;
    }

    private string CalcularTiempo(int tsegundos)
    {
        int horas = (tsegundos / 3600);
        int minutos = ((tsegundos - horas * 3600) / 60);
        int segundos = tsegundos - (horas * 3600 + minutos * 60);

        string hours = horas.ToString();
        string minutes = minutos.ToString();
        string seconds = segundos.ToString();


        if (horas < 10)
        {
            hours = "0" + horas.ToString();
        }

        if (minutos < 10)
        {
            minutes = "0" + minutos.ToString();
        }

        if (segundos < 10)
        {
            seconds = "0" + segundos.ToString();
        }

        return minutes + ":" + seconds;
    }

    public void resetTime()
    {
        switch (round)
        {
            case 0:
                limitTime = 90f;
                break;
            case 1:
                limitTime = 75f;
                break;
            case 2:
                limitTime = 60f;
                break;
        }
        time.gameObject.SetActive(false);
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Level3");
    }
}
