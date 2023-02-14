using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnerPoints;
    public GameObject enemyPrefabs;
    public bool generate;
    public float spawntiming;
    // Start is called before the first frame update
    void Start()
    {
        generate = false;
        spawntiming = 1;
        spawn();
        spawntimeControl();
    }

    // Update is called once per frame
    void Update()
    {
                  
    }

 
    void spawn()
    {
        if (generate == true)
        {
            Instantiate(enemyPrefabs, spawnerPoints.position, transform.rotation);
            generate = false;
        }            
        else if (generate == false)
        {
            generate = true;
        }

        Invoke("spawn", spawntiming);
    }

    void spawntimeControl()
    {
        spawntiming = Random.Range(1, 3.5f);
        Invoke("spawntimeControl", spawntiming);
    }
}
