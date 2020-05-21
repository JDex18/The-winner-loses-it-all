using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame4Manager : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loseHealth()
    {
        slider.value -= 10;
    }

    public void increaseHealth()
    {
        slider.value += 10;
    }
}
