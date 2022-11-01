using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class FrogAction : MonoBehaviour
{
    [SerializeField]
    private VirtualJoystick virtualJoystick;
    public float moveSpeed = 5;
    public float jumpPower = 5;

    AudioSource walkAudio;
    SpriteRenderer spriteRenderer;
    Animator anim;
    private Rigidbody2D rigid2D;

    public void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        walkAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
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
            //transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime; 기존 이동
            rigid2D.velocity = new Vector3(x, rigid2D.velocity.y, 0) * moveSpeed;

            // 걸을때 소리
            //if (!walkAudio.isPlaying)
            //    walkAudio.Play();
        }
        else
        {
            //walkAudio.Stop();
        }

        //방향전환
        if (x < 0)
            spriteRenderer.flipX = true;
        if (x > 0)
            spriteRenderer.flipX = false;

        //Jump
        if(Input.GetButtonDown("Jump") && !anim.GetBool("isJumping")){
            rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping",true);
        }
    }
}
