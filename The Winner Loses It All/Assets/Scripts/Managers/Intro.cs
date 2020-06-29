using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private float timer;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        text2.SetActive(false);
        text3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 4f)
        {
            text2.SetActive(true);
        }

        if (timer >= 8f)
        {
            text3.SetActive(true);
        }

        if(timer >= 18f)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
