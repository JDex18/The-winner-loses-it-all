using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public GameObject menu;
    public GameObject levels;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        levels.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void selectLevel()
    {
        menu.SetActive(false);
        levels.SetActive(true);
    }

    public void back()
    {
        levels.SetActive(false);
        menu.SetActive(true);
    }

    public void level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void level4()
    {
        SceneManager.LoadScene("Level4");
    }
}
