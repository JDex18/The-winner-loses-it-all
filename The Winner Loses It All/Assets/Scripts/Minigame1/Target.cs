using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject character;
    public GameObject finishCollider;
    private float timer;
    private bool reached;
    // Start is called before the first frame update
    void Start()
    {
        character.SetActive(false);
        timer = 0f;
        reached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (reached)
        {
            timer += Time.deltaTime;

            if(timer >= 0.5)
            {
                Debug.Log(Minigame1Manager.targetCount);
                gameObject.SetActive(false);               
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !reached)
        {
            character.SetActive(true);
            finishCollider.SetActive(true);
            reached = true;
            Minigame1Manager.targetCount++;

            if(Minigame1Manager.targetCount == 4)
            {
                FindObjectOfType<AudioManager>().parar("Ambiente");
                FindObjectOfType<AudioManager>().Play("Victoria");
            }

            else
            {
                FindObjectOfType<AudioManager>().Play("Acierto");
            }

        }
    }
}
