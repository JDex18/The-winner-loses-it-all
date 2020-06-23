using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    public GameObject menu;
    public GameObject levels;
    public GameObject options;
    public Controller controller;
    public Toggle toggle1;
    public Toggle toggle2;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        levels.SetActive(false);
        options.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Ambiente");

        toggle1.isOn = controller.music;
        toggle2.isOn = controller.soundEffects;

        controller.levelPlayed[0] = PlayerPrefs.GetInt("Level1", 0);
        controller.levelPlayed[1] = PlayerPrefs.GetInt("Level2", 0);
        controller.levelPlayed[2] = PlayerPrefs.GetInt("Level3", 0);
        controller.levelPlayed[3] = PlayerPrefs.GetInt("Level4", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("Boton");
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Boton");
        Application.Quit();
    }

    public void selectLevel()
    {
        menu.SetActive(false);
        levels.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Boton");
    }

    public void optionsMenu()
    {
        menu.SetActive(false);
        options.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Boton");
    }

    public void back()
    {
        levels.SetActive(false);
        options.SetActive(false);
        menu.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Boton2");
    }

    public void level1()
    {
        if(controller.levelPlayed[0] == 1)
        {
            FindObjectOfType<AudioManager>().Play("Boton");
            SceneManager.LoadScene("Level1");
        }
    }

    public void level2()
    {
        if (controller.levelPlayed[1] == 1)
        {
            FindObjectOfType<AudioManager>().Play("Boton");
            SceneManager.LoadScene("Level2");
        }
    }

    public void level3()
    {
        if (controller.levelPlayed[2] == 1)
        {
            FindObjectOfType<AudioManager>().Play("Boton");
            SceneManager.LoadScene("Level3");
        }
    }

    public void level4()
    {
        if (controller.levelPlayed[3] == 1)
        {
            FindObjectOfType<AudioManager>().Play("Boton");
            SceneManager.LoadScene("Level4");
        }
    }

    public void toggleMusic(bool value)
    {
        controller.music = value;

        if(value == false)
        {
            FindObjectOfType<AudioManager>().parar("Ambiente");
        }

        else
        {
            FindObjectOfType<AudioManager>().reanudar("Ambiente");
        }
    }

    public void toggleSound(bool value)
    {
        controller.soundEffects = value;
    }
}
