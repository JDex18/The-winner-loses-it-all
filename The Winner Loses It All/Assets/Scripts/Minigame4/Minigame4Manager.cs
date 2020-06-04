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
    public SpawnerMinigame4 spawnerMinigame;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 100;
        timer = 0f;
        start = false;
        time.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timer += Time.deltaTime;
            checkTimer();
            if (timer >= 120f)
            {
                timer = 120f;
                start = false;
                GameObject[] coinsToRemove = GameObject.FindGameObjectsWithTag("Coin");
                for (int i = 0; i < coinsToRemove.Length; i++)
                {
                    Destroy(coinsToRemove[i]);
                }
                canvasMinigame.loseGame();
                canvasMinigame.winGame();
            }

            time.text = CalcularTiempo(120 - (int)timer);
        }
    }

    public void loseHealth()
    {
        slider.value -= 10;

        if(slider.value <= 0 && start)
        {
            start = false;
            GameObject[] coinsToRemove = GameObject.FindGameObjectsWithTag("Coin");
            for (int i = 0; i < coinsToRemove.Length; i++)
            {
                Destroy(coinsToRemove[i]);
            }
            canvasMinigame.loseGame();
        }
    }

    public void increaseHealth()
    {
        slider.value += 10;
    }

    public void startTimer()
    {
        time.gameObject.SetActive(true);
        slider.gameObject.SetActive(true);
        slider.value = 100;
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
        slider.gameObject.SetActive(false);
    }

    private void checkTimer()
    {
        if (timer >= 30f && timer <= 60f)
        {
            spawnerMinigame.spawnDelay = 2.3f;
        }

        else if(timer >= 60f && timer <= 90f)
        {
            spawnerMinigame.spawnDelay = 1.8f;
        }

        else if (timer >= 90f)
        {
            spawnerMinigame.spawnDelay = 1.3f;
        }
    }
}
