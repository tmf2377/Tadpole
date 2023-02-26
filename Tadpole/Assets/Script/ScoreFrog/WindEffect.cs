using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour
{

   Rigidbody2D rigidbody;
    int speed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        speed = -1;
        Invoke("Delete", 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(speed, 0);      // 그 고도에서 비행
    }
    void Delete()
    {
        Destroy(gameObject);
    }

}
