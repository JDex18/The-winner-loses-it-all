using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTarget2 : MonoBehaviour
{
    public GameObject player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void talk()
    {
        transform.LookAt(player.transform);
        anim.SetBool("isTalking", true);
        FindObjectOfType<AudioManager>().Play("Dialogo");
    }
}
