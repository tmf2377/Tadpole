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
    public float maxSpeed;
    public float jumpPower;
    
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    AudioSource walkAudio;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        walkAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update(){
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();

        //Stop Speed
        if(x == 0){
            rigid.velocity = new Vector2(rigid.velocity.normalized.x*0.3f, rigid.velocity.y);
        }

        //방향전환
        if (x < 0){
            spriteRenderer.flipX = true;
        }
        if (x > 0)
            spriteRenderer.flipX = false;

        //Animation walk
        if(Mathf.Abs(rigid.velocity.x) < 0.2){
            anim.SetBool("isWalking", false);
        }else
            anim.SetBool("isWalking", true);
    }

    void FixedUpdate(){
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();

        if (x != 0 || y != 0){
            
            //Move Speed
            rigid.AddForce(Vector2.right*x,ForceMode2D.Impulse);
            
            //MaxSpeed
            if(rigid.velocity.x > maxSpeed){
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            }else if(rigid.velocity.x < maxSpeed*(-1)){
                rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
            }
        }

        //Landing Platform
        if(rigid.velocity.y<0){
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0,1,0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if(rayHit.collider != null){
                if(rayHit.distance < 0.5f)
                    anim.SetBool("isJumping",false);
            }
        }
    }

    public void JumpButton(){
        if(!anim.GetBool("isJumping")){
            rigid.AddForce(Vector2.up*jumpPower,ForceMode2D.Impulse);
            anim.SetBool("isJumping",true);
        }
    }
    /*
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
            //rigid2D.velocity = new Vector3(x, rigid2D.velocity.y, 0) * moveSpeed;
            rigid2D.AddForce(Vector2.right*x.ForceMode2D.Impulse);
            
            if(rigid2D.velocity.normalized.x == 0){
            anim.SetBool("isWalking", false);
            }else
            anim.SetBool("isWalking", true);
            
            // 걸을때 소리
            //if (!walkAudio.isPlaying)
            //    walkAudio.Play();
        }
        else
        {
            //rigid2D.velocity = new Vector2(rigid2D.velocity.normalized.x*0.5f,rigid2D);
            //walkAudio.Stop();
        }

        //방향전환
        if (x < 0){
            spriteRenderer.flipX = true;
        }
        if (x > 0)
            spriteRenderer.flipX = false;

        //Animation walk
        if(rigid2D.velocity.normalized.x == 0){
            anim.SetBool("isWalking", false);
        }else
            anim.SetBool("isWalking", true);

        //Animation Jump
        if(Input.GetButtonDown("Jump") && !anim.GetBool("isJumping")){
            rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping",true);
        }
    }*/
}
