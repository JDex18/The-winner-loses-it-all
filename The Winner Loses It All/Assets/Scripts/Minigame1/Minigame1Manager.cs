using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame1Manager : MonoBehaviour
{
    public static int targetCount;
    // Start is called before the first frame update
    void Start()
    {
        targetCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetCount == 4)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
