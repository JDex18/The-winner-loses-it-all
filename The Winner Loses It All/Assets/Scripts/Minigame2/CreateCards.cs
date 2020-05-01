using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCards : MonoBehaviour
{
    public GameObject cardPrefab;
    public int width;

    public Material[] materials;
    public Texture2D[] textures;
    private List<GameObject> cards = new List<GameObject>();

    public Card showedCard;
    public bool canShow;

    // Start is called before the first frame update
    void Start()
    {
        create();//PROVISIONAL. PONLO DESPUÉS DONDE QUIERAS QUE SE EMPIECEN A CREAR LAS CARTAS
        canShow = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void create()
    {
        for(int i = 0; i < width; i++)
        {
            for(int x = 0; x < width; x++)
            {
                GameObject card = Instantiate(cardPrefab, new Vector3(x, 0, i), Quaternion.Euler(new Vector3(0, 180, 0)));
                cards.Add(card);
                card.GetComponent<Card>().assignTexture(textures[0]);
                card.GetComponent<Card>().startPosition = new Vector3(x, 0, i);
            }

        }

        assignTextures();
        mixCards();

    }

    private void assignTextures()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            cards[i].GetComponent<Card>().assignTexture(textures[i / 2]);
            cards[i].GetComponent<Card>().numCard = i / 2;
        }
    }

    private void mixCards()
    {
        int random = 0;
        for (int i = 0; i < cards.Count; i = i + 2)
        {
            random = Random.Range(i, cards.Count);

            cards[i].transform.position = cards[random].transform.position;
            cards[random].transform.position = cards[i].GetComponent<Card>().startPosition;

            cards[i].GetComponent<Card>().startPosition = cards[i].transform.position;
            cards[random].GetComponent<Card>().startPosition = cards[random].transform.position;
        }
    }

    public void click(Card card)
    {
        if(showedCard == null)
        {
            showedCard = card;
        }

        else
        {
            if(checkCards(showedCard.gameObject, card.gameObject))
            {
                Debug.Log("ACIERTO");
                canShow = true;
            }

            else
            {
                Debug.Log("FALLO");
                card.hideCard();
                showedCard.hideCard();
            }

            showedCard = null;
        }
    }

    private bool checkCards(GameObject card1, GameObject card2)
    {
        return card1.GetComponent<Card>().numCard == card2.GetComponent<Card>().numCard;
    }
}
