using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonsController : MonoBehaviour
{
    public static bool paused;
    public GameObject pauseMenu;
    public bool canPause;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        canPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (paused)
                {
                    resume();
                }

                else
                {
                    pause();
                }

                FindObjectOfType<AudioManager>().Play("Pausa");
            }
        }
        
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        FindObjectOfType<AudioManager>().Play("Pausa");
        FindObjectOfType<AudioManager>().reanudar("Ambiente");
        FindObjectOfType<AudioManager>().reanudar("Ambiente2");
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        FindObjectOfType<AudioManager>().parar("Ambiente");
        FindObjectOfType<AudioManager>().parar("Ambiente2");
    }

    public void backToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void activatePauseMenu()
    {
        canPause = true;
    }

    public void deactivatePauseMenu()
    {
        canPause = false;
    }
}
