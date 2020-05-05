using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame1Manager : MonoBehaviour
{
    public static int targetCount;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        targetCount = 0;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetCount == 4)
        {
            timer += Time.deltaTime;
            if(timer >= 3f)
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }
}
