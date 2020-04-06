using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawn;
    public Transform spawn2;
    public GameObject[] vehicles;

    public Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        controller.enPaso = false;
        InvokeRepeating("spawner", 2f, 7f);
        InvokeRepeating("spawner2", 2.5f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawner()
    {
        if (!controller.enPaso)
        {
            //Instantiate(car, spawn.position, spawn.rotation);
            Instantiate(vehicles[Random.Range(0, vehicles.Length)], spawn.position, spawn.rotation);
        }   
    }

    void spawner2()
    {
        if (!controller.enPaso)
        {
            //Instantiate(car, spawn2.position, spawn2.rotation);
            Instantiate(vehicles[Random.Range(0, vehicles.Length)], spawn2.position, spawn2.rotation);
        }
    }
}
