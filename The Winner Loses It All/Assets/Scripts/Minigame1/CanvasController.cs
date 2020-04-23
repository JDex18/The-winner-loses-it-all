using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Sprite image2;
    public Sprite image1;
    public Sprite imageYa;


    public GameObject instructions;
    //public GameObject contador;
    public Image cuenta;

    private bool start;
    private float timer;

    public static bool fail;
    public static bool good;
    public Image textoCentral;
    public Sprite failImage;
    public Sprite goodImage;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        timer = 0f;

        fail = false;
        good = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fail || good)
        {
            textoCentral.gameObject.SetActive(true);
            checkState();
            timer += Time.deltaTime;

            if(timer >= 2f)
            {
                timer = 0;
                textoCentral.gameObject.SetActive(false);
                fail = false;
                good = false;
            }
            
        }

        if (!PlayerMovement22.play)
        {
            if (!start)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    start = true;
                    instructions.SetActive(false);
                    cuenta.gameObject.SetActive(true);
                }
            }

            else
            {
                timer += Time.deltaTime;

                if (timer >= 1f && timer <= 2f)
                {
                    cuenta.sprite = image2;
                }

                else if (timer >= 2f && timer <= 3f)
                {
                    cuenta.sprite = image1;
                }

                else if (timer >= 3f && timer <= 4f)
                {
                    cuenta.sprite = imageYa;
                }

                else if (timer >= 4f)
                {
                    cuenta.gameObject.SetActive(false);
                    timer = 0;
                    PlayerMovement22.play = true;
                }
            }
        }       
    }

    private void checkState()
    {
        if (fail)
        {
            textoCentral.sprite = failImage;
        }

        if (good)
        {
            textoCentral.sprite = goodImage;
        }
    }
}
