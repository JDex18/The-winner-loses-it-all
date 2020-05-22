using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMinigame4 : MonoBehaviour
{
    public float spawnDelay;
    private float nextTimeToSpawn;

    public GameObject[] objects;
    public GameObject[] objectsGood;
    public Transform[] spawnPoints;

    private int random;
    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = 3f;
        nextTimeToSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextTimeToSpawn <= Time.time && PlayerMovementMinigame4.play)
        {
            spawnObject();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void spawnObject()
    {
        random = Random.Range(0, 5);
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        if (random == 0)
        {
            Instantiate(objectsGood[Random.Range(0, objectsGood.Length)], spawnPoint.position, spawnPoint.rotation);
        }

        else
        {
            Instantiate(objects[Random.Range(0, objects.Length)], spawnPoint.position, spawnPoint.rotation);
        }
        
        
    }
}
