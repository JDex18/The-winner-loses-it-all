using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    private float spawnDelay;
    private float nextTimeToSpawn;

    public GameObject obstacle;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = 0.5f;
        nextTimeToSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(nextTimeToSpawn <= Time.time)
        {
            spawnObstacle();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
        
    }

    void spawnObstacle()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(obstacle, spawnPoint.position, spawnPoint.rotation);
    }
}
