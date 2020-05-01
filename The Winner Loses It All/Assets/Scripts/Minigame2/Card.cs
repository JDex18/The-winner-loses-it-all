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
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        timeDelay = 1f;
        showing = false;
    }

    private void Awake()
    {
        createCards = GameObject.Find("GameManager").GetComponent<CreateCards>();
        anim = GetComponent<Animator>();
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
            //GetComponent<MeshRenderer>().material.mainTexture = assignedTexture;
            anim.SetBool("isShowing", true);
            Invoke("idle", 0.3f);
            createCards.click(this);
            showing = true;
        }
    }

    public void show()
    {
        GetComponent<MeshRenderer>().material.mainTexture = assignedTexture;
    }

    public void hideCard()
    {
        createCards.canShow = false;
        //Invoke("hide", timeDelay);
        Invoke("hideAnimation", timeDelay);
    }

    private void hideAnimation()
    {
        anim.SetBool("isHiding", true);
        Invoke("idle", 0.3f);
    }

    public void hide()
    {
        GetComponent<MeshRenderer>().material = hideCardMaterial;
        createCards.canShow = true;
        showing = false;
    }

    private void idle()
    {
        anim.SetBool("isHiding", false);
        anim.SetBool("isShowing", false);
    }

    private void OnMouseDown()
    {
        showCard();
    }

    
}
