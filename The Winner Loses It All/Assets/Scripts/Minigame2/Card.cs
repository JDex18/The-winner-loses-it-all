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

    // Start is called before the first frame update
    void Start()
    {
        timeDelay = 1f;
    }

    private void Awake()
    {
        createCards = GameObject.Find("GameManager").GetComponent<CreateCards>();
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
        if (createCards.canShow)
        {
            GetComponent<MeshRenderer>().material.mainTexture = assignedTexture;
            createCards.click(this);
        }
    }

    public void hideCard()
    {
        createCards.canShow = false;
        Invoke("hide", timeDelay);
    }

    private void hide()
    {
        GetComponent<MeshRenderer>().material = hideCardMaterial;
        createCards.canShow = true;
    }

    private void OnMouseDown()
    {
        showCard();
    }

    
}
