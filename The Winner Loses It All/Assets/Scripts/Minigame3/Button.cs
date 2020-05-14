using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int numButton;
    private float lightIntensity;
    public Light light;

    private bool disabling;
    private bool disabled;

    public ButtonsManager buttonsManager;

    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        lightIntensity = light.intensity;
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(disabling && !disabled)
        {
            light.intensity = Mathf.Lerp(light.intensity, 0f, 0.1f);//la velocidad original es 0.065f

            if (light.intensity <= 0.02)
            {
                light.intensity = 0f;
                disabled = true;
            }
        }
    }

    public void enableButton()
    {
        disabling = false;
        disabled = false;
        light.intensity = lightIntensity;
        light.gameObject.SetActive(true);
        if (buttonsManager.playerTurn)
        {
            buttonsManager.playerClick(numButton);
        }
        /*switch (numButton)
        {
            case 0:
                anim.Play("ButtonAnimationGreen");
                break;
            case 1:
                anim.Play("ButtonAnimationRed");
                break;
            case 2:
                anim.Play("ButtonAnimationYellow");
                break;
            case 3:
                anim.Play("ButtonAnimationBlue");
                break;
        }*/
        anim.Play();
        Invoke("disableButton", 0.1f);
    }

    public void disableButton()
    {
        disabling = true;
    }

    private void OnMouseDown()
    {
        if (buttonsManager.playerTurn)
        {
            enableButton();
        }
    }
}
