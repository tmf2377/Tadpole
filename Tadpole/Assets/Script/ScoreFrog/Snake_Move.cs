using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Move : MonoBehaviour
{
     Rigidbody2D rigidbody;
     Transform transform;
     public GameObject Frog;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.position = new Vector2(Frog.transform.position.x,this.rigidbody.position.y);
    }
}
