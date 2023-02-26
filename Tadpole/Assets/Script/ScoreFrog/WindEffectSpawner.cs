using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffectSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject windEffect;
    int spawnTime;
    void Start()
    {
        spawnTime = 0;
    }

    void Update()
    {
        //spawnTime += Time.deltaTime;
        spawnTime++;
        if (spawnTime % 15 == 0)
        {
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(windEffect, spawnPoints[randSpawnPoint].position, transform.rotation);
        }
    }

   
}
