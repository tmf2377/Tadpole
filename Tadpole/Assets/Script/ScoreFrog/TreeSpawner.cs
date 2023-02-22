using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public Transform spawnerPoints;
    public GameObject treePrefabs;
    public bool generate;

    // Start is called before the first frame update
    void Start()
    {
        generate = true;
        spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void spawn()
    {
        if (generate == true)
        {
            Instantiate(treePrefabs, spawnerPoints.position, transform.rotation);
            generate = false;
        }
        else if (generate == false)
        {
            generate = true;
        }

        Invoke("spawn", 5);
    }    
}
