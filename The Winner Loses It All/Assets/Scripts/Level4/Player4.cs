using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4 : MonoBehaviour
{
    public Controller controller;
    public Level4Canvas levelCanvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            controller.enConversacion = true;
            levelCanvas.finish();
        }
    }
}
