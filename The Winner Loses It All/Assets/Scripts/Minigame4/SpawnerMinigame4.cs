using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMinigame4 : MonoBehaviour
{
    private float spawnDelay;
    private float nextTimeToSpawn;

    public GameObject[] objects;
    public Transform[] spawnPoints;
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
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(objects[Random.Range(0, objects.Length)], spawnPoint.position, spawnPoint.rotation);
    }
}
