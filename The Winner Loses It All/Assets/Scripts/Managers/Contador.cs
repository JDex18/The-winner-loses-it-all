using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void soundCounter()
    {
        FindObjectOfType<AudioManager>().Play("Contador");
    }

    public void soundFinishCounter()
    {
        FindObjectOfType<AudioManager>().Play("Start");
    }
}
