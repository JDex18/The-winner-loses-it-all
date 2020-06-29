using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private float timer;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject finalPanel;
    public GameObject intro;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        intro.SetActive(true);
        finalPanel.SetActive(false);
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Ambiente");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 6f)
        {
            text1.SetActive(true);
        }

        if (timer >= 12f)
        {
            text2.SetActive(true);
        }

        if (timer >= 18f)
        {
            text3.SetActive(true);
        }

        if (timer >= 24f)
        {
            text4.SetActive(true);
        }

        if (timer >= 40f)
        {
            finalPanel.SetActive(true);
        }

        if (timer >= 46f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
