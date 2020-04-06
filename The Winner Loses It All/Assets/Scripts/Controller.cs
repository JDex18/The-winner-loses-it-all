using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Controller", menuName = "Controller")]
public class Controller : ScriptableObject
{
    public bool enConversacion;

    public List<string[]> dialogosDePersonajes = new List<string[]>();

    public bool enPaso;

    /*[System.Serializable]
    public class MyArray
    {
        [System.Serializable]
        public struct frases
        {
            public Text[] frase;
        }

        public frases[] Frases = new frases[7];
        //Text[] frases;
    }

    //public MyArray[] dialogos;*/

}
