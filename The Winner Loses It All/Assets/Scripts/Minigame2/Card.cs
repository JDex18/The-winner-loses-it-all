using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int numCard;
    public Vector3 startPosition;
    private Texture2D assignedTexture;
    public Material hideCardMaterial;
    public CreateCards createCards;

    private float timeDelay;
    private bool showing;
    //private Animator anim;
    private Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        timeDelay = 3f;
        showing = true;
    }

    private void Awake()
    {
        createCards = GameObject.Find("GameManager").GetComponent<CreateCards>();
        //anim = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        Invoke("show", 0.1f);
        Invoke("hideAnimation", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void assignTexture(Texture2D texture)
    {
        assignedTexture = texture;
    }

    public void showCard()
    {
        if (createCards.canShow && !showing)
        {
            //anim.SetBool("isShowing", true);
            animation.Play("showAnimation");
            //Invoke("idle", 0.3f);
            createCards.click(this);
            showing = true;
            FindObjectOfType<AudioManager>().Play("Giro");
        }
    }

    public void show()//SE LLAMA DESDE UN EVENTO DE LA ANIMACIÓN
    {
        GetComponent<MeshRenderer>().material.mainTexture = assignedTexture;
    }

    public void hideCard()
    {
        createCards.canShow = false;
        Invoke("hideAnimation", timeDelay);
    }

    private void hideAnimation()
    {
        //anim.SetBool("isHiding", true);
        animation.Play("hideAnimation");
        //Invoke("idle", 0.3f);
        FindObjectOfType<AudioManager>().Play("Giro");
    }

    public void hide()//SE LLAMA DESDE UN EVENTO DE LA ANIMACIÓN
    {
        GetComponent<MeshRenderer>().material = hideCardMaterial;
        createCards.canShow = true;
        showing = false;
    }

    /*private void idle()
    {
        anim.SetBool("isHiding", false);
        anim.SetBool("isShowing", false);
    }*/

    private void OnMouseDown()
    {
        showCard();
    }

    
}
