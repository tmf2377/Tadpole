using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class Tadpole_score : MonoBehaviour
{
    [SerializeField]
    private VirtualJoystick virtualJoystick;
    public float moveSpeed = 4.5f;
    AudioSource walkAudio;
    SpriteRenderer spriteRenderer;

    private Rigidbody2D rigid2D;

    public void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        walkAudio = GetComponent<AudioSource>();
    }


    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();

        if (x != 0 || y != 0)
        {
            rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;

        }
        else
        {

        }

        //방향전환
        if (x < 0)
            spriteRenderer.flipX = true;
        if (x > 0)
            spriteRenderer.flipX = false;

        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;
        }
    }

}
