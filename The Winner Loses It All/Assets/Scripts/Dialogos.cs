using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public Controller controller;

    string[] personaje1 = new string[2];
    string[] personaje2 = new string[3];
    string[] personaje3 = new string[12];//este personaje es del nivel 4, así que al añadir el resto de diálogos acúerdate de mover este al final

    // Start is called before the first frame update
    void Start()
    {
        rellenarPersonaje1();
        rellenarPersonaje2();
        rellenarPersonaje3();

        //CUIDADO AL AÑADIR LOS ARRAYS A LA LISTA. SE VAN COLOCANDO EN ORDEN, DE FORMA QUE ASEGURATE QUE LA ID DEL PERSONAJE CORRESPONDE CON LA POSICIÓN DENTRO DE LA LISTA CORRESPONDIENTE
        controller.dialogosDePersonajes.Add(personaje1);
        controller.dialogosDePersonajes.Add(personaje2);
        controller.dialogosDePersonajes.Add(personaje3);
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

    void rellenarPersonaje3()//los textos que hay ahora tendrás que moverlos al método para los diálogos del último personaje
    {
        personaje3[0] = "Raúl: Hola Toni, cuanto tiempo";
        personaje3[1] = "Jose: Eyy Toni";
        personaje3[2] = "Toni: Hola chicos, me he perdido algo?";
        personaje3[3] = "Raúl: Nada, hemos estado comentando el partido de anoche. Lo viste?";
        personaje3[4] = "Toni: No... la verdad es que no. Tenía otras cosas que hacer...";
        personaje3[5] = "Raúl: Bueno tampoco te perdiste nada. Que tal el trabajo?";
        personaje3[6] = "Toni: Bien, como siempre. Oye gracias por el dinero que me prestaste. He estado teniendo algunos problemas, pero te lo devolveré en cuanto pueda";
        personaje3[7] = "Raúl: No te preocupes Toni, para algo están los amigos";
        personaje3[8] = "Toni: Gracias, de verdad. Me alegro de veros";
        personaje3[9] = "Raúl: Y nosotros a ti. Oye, Jose y yo vamos a tomarnos otra caña. Te apuntas?";
        personaje3[10] = "Toni: Claro, pero tengo que ir momento al  baño antes. Sabéis donde está?";
        personaje3[11] = "Raúl: Oh sí, me olvidaba de que aún no habías venido a este bar. Está a la derecha de la barra. Sigue por ese pasillo y llegarás";
    }
}
