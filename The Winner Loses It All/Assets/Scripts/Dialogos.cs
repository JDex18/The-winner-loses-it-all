using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public Controller controller;

    string[] personaje1 = new string[6];
    string[] personaje2 = new string[4];
    string[] personaje3 = new string[4];
    string[] personaje4 = new string[7];
    string[] personaje5 = new string[4];
    string[] personaje6 = new string[12];
    string[] personaje7 = new string[13];
    string[] personaje8 = new string[4];
    string[] personaje9 = new string[10];
    string[] personaje10 = new string[12];

    // Start is called before the first frame update
    void Start()
    {
        rellenarPersonaje1();
        rellenarPersonaje2();
        rellenarPersonaje3();
        rellenarPersonaje4();
        rellenarPersonaje5();
        rellenarPersonaje6();
        rellenarPersonaje7();
        rellenarPersonaje8();
        rellenarPersonaje9();
        rellenarPersonaje10();

        //CUIDADO AL AÑADIR LOS ARRAYS A LA LISTA. SE VAN COLOCANDO EN ORDEN, DE FORMA QUE ASEGURATE QUE LA ID DEL PERSONAJE CORRESPONDE CON LA POSICIÓN DENTRO DE LA LISTA CORRESPONDIENTE
        controller.dialogosDePersonajes.Add(personaje1);
        controller.dialogosDePersonajes.Add(personaje2);
        controller.dialogosDePersonajes.Add(personaje3);
        controller.dialogosDePersonajes.Add(personaje4);
        controller.dialogosDePersonajes.Add(personaje5);
        controller.dialogosDePersonajes.Add(personaje6);
        controller.dialogosDePersonajes.Add(personaje7);
        controller.dialogosDePersonajes.Add(personaje8);
        controller.dialogosDePersonajes.Add(personaje9);
        controller.dialogosDePersonajes.Add(personaje10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void rellenarPersonaje1() //RELLENA EL ARRAY DE LAS FRASES DEL PERSONAJE CON SUS FRASES CORRESPONDIENTES
    {
        personaje1[0] = "Ruben: Hola Toni. Has escuchado lo de la casa de apuestas?";
        personaje1[1] = "Toni: Que casa de apuestas?";
        personaje1[2] = "Ruben: Han abierto una a dos calles de aquí. Te lo puedes creer? Tan cerca del colegio";
        personaje1[3] = "Toni: No había escuchado nada...";
        personaje1[4] = "Ruben: Pues no sé como no te has enterado. Hay carteles por toda la calle. Publicidad de ese sitio. 'Casino' lo han llamado. No tienen vergüenza.";
        personaje1[5] = "Ruben: En fin, si quieres unirte, mañana algunos de los padres nos manifestaremos frente a la casa de apuestas. Hasta luego Toni.";
    }

    void rellenarPersonaje2()
    {
        personaje2[0] = "Anciano: Parece que han abierto un nuevo casino por aquí cerca";
        personaje2[1] = "Anciano: Es genial, así podré acercarme cuando recoja a mi nieto del colegio y divertirme un poco";
        personaje2[2] = "Anciano: Sé que en teoría no dejan entrar a menores, pero bueno, suelen hacer la vista gorda";
        personaje2[3] = "Anciano: Así que por qué no iban a hacerla con mi nieto? Solo será un rato";
    }

    void rellenarPersonaje3()
    {
        personaje3[0] = "Anciana: No me puedo creer que hayan puesto esa cosa tan cerca del colegio";
        personaje3[1] = "Anciana: Mi hijo se enganchó a las apuestas, y ahora ha perdido su trabajo y tiene una deuda que nos va a llevar a toda la familia a la ruina";
        personaje3[2] = "Anciana: Hagáme un favor y no caiga en lo mismo señor. Nadie merece eso";
        personaje3[3] = "Toni: ...";
    }

    void rellenarPersonaje4()
    {
        personaje4[0] = "Joven: Las apuestas deportivas son una lacra para la sociedad. El juego, la ruleta... son todo patrañas";
        personaje4[1] = "Joven: No son más que drogas que destrozan a la clase obrera";
        personaje4[2] = "Joven: Empiezan ofreciendo comida y bebida gratis";
        personaje4[3] = "Joven: Te 'regalan' dinero para que empieces a engancharte, y lo peor que te puede ocurrir es que ganes la primera vez que apuestas";
        personaje4[4] = "Joven: Luego no puedes parar";
        personaje4[5] = "Joven: Pero no vamos a dejar que pasen por encima de nuestros barrios. Su riqueza es tu miseria";
        personaje4[6] = "Joven: Fuera las casas de apuestas de nuestros barrios!";
    }

    void rellenarPersonaje5()
    {
        personaje5[0] = "Desconocido: Pues yo no entiendo por qué se quejan tanto de las casas de apuestas";
        personaje5[1] = "Desconocido: Pasas un buen rato echando la ruleta o jugando una partida de póker y encima te llevas dinero";
        personaje5[2] = "Desconocido: Si luego no sabes controlarte no es problema de los demás";
        personaje5[3] = "Desconocido: No entiendo por qué se lo toman así. No es tan serio";
    }

    void rellenarPersonaje6()
    {
        personaje6[0] = "Daniel: Hola papá";
        personaje6[1] = "Toni: Hola Daniel, que tal el colegio hoy?";
        personaje6[2] = "Daniel: Bien, hoy hemos jugado un pártido de futbol y mi equipo ha ganado";
        personaje6[3] = "Toni: Eso es genial. Me alegro";
        personaje6[4] = "Daniel: Oye, mamá me ha dicho que te lo pregunte a ti. En mi juego de fútbol favorito venden unos sobres con los que pueden tocarte jugadores";
        personaje6[5] = "Daniel: Y quiero comprarme unos cuantos para ver si me toca mi jugador favorito. Puedes dejarme dinero?";
        personaje6[6] = "Toni: Como que puede tocarte?";
        personaje6[7] = "Daniel: Sí, es como una de esas máquinas que sueltan dinero, las de los casinos. Pero lo que te dan son jugadores";
        personaje6[8] = "Toni: No me parece muy buena idea...";
        personaje6[9] = "Daniel: Pero papá, mi jugador favorito sale en los anuncios de los sobres. No sé cual es el problema";
        personaje6[10] = "Toni: Lo hablaré con tu madre, vale?";
        personaje6[11] = "Daniel: De acuerdo...";
    }

    void rellenarPersonaje7()
    {
        personaje7[0] = "Toni: Hola Rosa, que tal todo?";
        personaje7[1] = "Rosa: Toni... la verdad es que no muy bien";
        personaje7[2] = "Toni: Qué ocurre?";
        personaje7[3] = "Rosa: Es mi hijo, Jaime. Sabes que tuvo un problema con las drogas, no?";
        personaje7[4] = "Toni: Sí, recuerdo esa época. Pero superó la rehabilitación, no?";
        personaje7[5] = "Rosa: Sí, y llevaba un par de años limpio. Pero hace un tiempo empezó a visitar páginas de apuestas";
        personaje7[6] = "Rosa: Yo no le di importancia porque bueno, pensaba que era una forma más de entretenerse";
        personaje7[7] = "Rosa: Pero ahora está enganchado. Es como si hubiera sustituido una adicción por otra, y estoy preocupada";
        personaje7[8] = "Toni: Lo siento Rosa...";
        personaje7[9] = "Rosa: Hoy voy a intentar convencerlo para ir a una reunión con otros ludópatas";
        personaje7[10] = "Rosa: Tiene que ver que tiene un problema, pero que puede salir de ahí, y que yo le apoyo";
        personaje7[11] = "Toni: ...pues os deseo lo mejor Rosa";
        personaje7[12] = "Rosa: Gracias Toni";
    }

    void rellenarPersonaje8()
    {
        personaje8[0] = "Compañero: Que ganas de salir del trabajo";
        personaje8[1] = "Compañero: Me aposté con Enrique quien ganaba la Liga, y he ganado";
        personaje8[2] = "Compañero: Así que ahora me debe dos rondas en el bar";
        personaje8[3] = "Compañero: Tendría que haber apostado dinero. Lo tendré en cuenta para la próxima. Le estoy cogiendo el gusto a esto";
    }

    void rellenarPersonaje9()
    {
        personaje9[0] = "Desconocido: Oye perdona, pero te conozco de algo?";
        personaje9[1] = "Toni: No creo, la verdad...";
        personaje9[2] = "Desconocido: Ahh claro, ya se quién eres. Solías ir a la casa de apuestas de San Ramón no?";
        personaje9[3] = "Desconocido: Puede que alguna vez estuviera...";
        personaje9[4] = "Desconocido: Sí, eras el que siempre se echaba un par de rondas en la ruleta antes de tirarse casi una hora en la máquina";
        personaje9[5] = "Desconocido: Llevo tiempo sin verte por ahí";
        personaje9[6] = "Toni: Estoy intentando alejarme de todo eso...";
        personaje9[7] = "Desconocido: Ahh bueno, eres uno de esos";
        personaje9[8] = "Desconocido: Bueno pues a ver si tienes suerte, porque los demás de momento vamos a seguir metidos en la trampa para ratones jajajajaja";
        personaje9[9] = "Toni: Tengo que irme";
    }

    void rellenarPersonaje10()//los textos que hay ahora tendrás que moverlos al método para los diálogos del último personaje
    {
        personaje10[0] = "Raúl: Hola Toni, cuanto tiempo";
        personaje10[1] = "Jose: Eyy Toni";
        personaje10[2] = "Toni: Hola chicos, me he perdido algo?";
        personaje10[3] = "Raúl: Nada, hemos estado comentando el partido de anoche. Lo viste?";
        personaje10[4] = "Toni: No... la verdad es que no. Tenía otras cosas que hacer...";
        personaje10[5] = "Raúl: Bueno tampoco te perdiste nada. Que tal el trabajo?";
        personaje10[6] = "Toni: Bien, como siempre. Oye gracias por el dinero que me prestaste. He estado teniendo algunos problemas, pero te lo devolveré en cuanto pueda";
        personaje10[7] = "Raúl: No te preocupes Toni, para algo están los amigos";
        personaje10[8] = "Toni: Gracias, de verdad. Me alegro de veros";
        personaje10[9] = "Raúl: Y nosotros a ti. Oye, Jose y yo vamos a tomarnos otra caña. Te apuntas?";
        personaje10[10] = "Toni: Claro, pero tengo que ir momento al  baño antes. Sabéis donde está?";
        personaje10[11] = "Raúl: Oh sí, me olvidaba de que aún no habías venido a este bar. Está a la derecha de la barra. Sigue por ese pasillo y llegarás";
    }
}
