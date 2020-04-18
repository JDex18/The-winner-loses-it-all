using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    private float spawnDelay;
    private float nextTimeToSpawn;

    private float spawnDelayPlattforms;
    private float nextTimeToSpawnPlattforms;

    public GameObject obstacle;
    public GameObject[] plattforms;
    public Transform[] spawnPoints;
    public Transform[] spawnPoints2;

    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = 1.5f;
        nextTimeToSpawn = 0f;

        spawnDelayPlattforms = 1.5f;
        nextTimeToSpawnPlattforms = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(nextTimeToSpawn <= Time.time)
        {
            spawnObstacle();
            nextTimeToSpawn = Time.time + spawnDelay;
        }

        if (nextTimeToSpawnPlattforms <= Time.time)
        {
            spawnPlattform();
            nextTimeToSpawnPlattforms = Time.time + spawnDelayPlattforms;
        }

    }

    void spawnObstacle()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, 2)];
        Instantiate(obstacle, spawnPoint.position, spawnPoint.rotation);

        spawnPoint = spawnPoints[Random.Range(2, 4)];
        Instantiate(obstacle, spawnPoint.position, spawnPoint.rotation);

        spawnPoint = spawnPoints[Random.Range(4, spawnPoints.Length)];
        Instantiate(obstacle, spawnPoint.position, spawnPoint.rotation);
    }

    void spawnPlattform()
    {
        Transform spawnPoint = spawnPoints2[Random.Range(0, 2)];
        Instantiate(plattforms[Random.Range(0, plattforms.Length)], spawnPoint.position, spawnPoint.rotation);

        spawnPoint = spawnPoints2[Random.Range(2, spawnPoints2.Length)];
        Instantiate(plattforms[Random.Range(0, plattforms.Length)], spawnPoint.position, spawnPoint.rotation);
    }
}
