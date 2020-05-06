using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame2Manager : MonoBehaviour
{
    public Text time;
    private float timer;
    private bool start;

    // Start is called before the first frame update
    void Start()
    {
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
            if(timer >= 90f)
            {
                timer = 90f;
                start = false;
            }

            time.text = CalcularTiempo(60 - (int)timer);
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
}
