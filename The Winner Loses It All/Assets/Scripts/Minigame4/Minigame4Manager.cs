using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame4Manager : MonoBehaviour
{
    public Slider slider;
    public Text time;
    private float timer;
    public static bool start;
    public CanvasMinigame4 canvasMinigame;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 100;
        timer = 0f;
        start = false;
        time.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timer += Time.deltaTime;
            if (timer >= 120f)
            {
                timer = 120f;
                start = false;
                canvasMinigame.winGame();
            }

            time.text = CalcularTiempo(120 - (int)timer);
        }
    }

    public void loseHealth()
    {
        slider.value -= 10;
    }

    public void increaseHealth()
    {
        slider.value += 10;
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
        time.gameObject.SetActive(false);
    }
}
