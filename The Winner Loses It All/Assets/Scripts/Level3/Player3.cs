using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    public Controller controller;
    public Level3Canvas levelCanvas;
    public NPCTarget2 npc;
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
        if(other.tag == "Finish")
        {
            controller.enConversacion = true;
            npc.talk();
            transform.LookAt(npc.gameObject.transform);
            levelCanvas.finish();
        }
    }
}
