using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public Controller controller;

    string[] personaje1 = new string[2];
    string[] personaje2 = new string[3];

    // Start is called before the first frame update
    void Start()
    {
        rellenarPersonaje1();
        rellenarPersonaje2();

        //CUIDADO AL AÑADIR LOS ARRAYS A LA LISTA. SE VAN COLOCANDO EN ORDEN, DE FORMA QUE ASEGURATE QUE LA ID DEL PERSONAJE CORRESPONDE CON LA POSICIÓN DENTRO DE LA LISTA CORRESPONDIENTE
        controller.dialogosDePersonajes.Add(personaje1);
        controller.dialogosDePersonajes.Add(personaje2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void rellenarPersonaje1() //RELLENA EL ARRAY DE LAS FRASES DEL PERSONAJE CON SUS FRASES CORRESPONDIENTES
    {
        personaje1[0] = "Hola";
        personaje1[1] = "Que tal?";
    }

    void rellenarPersonaje2()
    {
        personaje2[0] = "Eyy";
        personaje2[1] = "Que te cuentas?";
        personaje2[2] = "Me alegro";
    }
}
