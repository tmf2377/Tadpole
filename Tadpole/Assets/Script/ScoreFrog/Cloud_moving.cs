﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_moving : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(speed, 0);      // 그 고도에서 비행
        if (this.rigid.position.x > 20 || this.rigid.position.x < -12)
        {
            Destroy(gameObject);
        }
    }

    
}