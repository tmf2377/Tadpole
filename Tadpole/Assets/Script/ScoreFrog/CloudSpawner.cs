using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public Transform spawnerPoints;
    public GameObject cloudPrefabs;
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
            Instantiate(cloudPrefabs, spawnerPoints.position, transform.rotation);
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
        spawntiming = Random.Range(5, 15f);
        Invoke("spawntimeControl", spawntiming);
    }
}
