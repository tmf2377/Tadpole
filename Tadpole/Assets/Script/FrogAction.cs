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

    private int jumpCount = 2;
    private bool isGround = false;
    
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

    void Start()
    {
        jumpCount = 0;
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            jumpCount = 2;
            Debug.Log("0");
        }
    }*/

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
                {
                    anim.SetBool("isJumping", false);
                }

            }
        }

        if (rigid.velocity.y == 0)
        {
            isGround = true;
            jumpCount = 2;
        }
        else
            isGround = false;

        
    }

    public void JumpButton(){
        if (jumpCount > 0)
        {
            if(jumpCount == 1)
            {
                rigid.AddForce(Vector2.up * jumpPower/2, ForceMode2D.Impulse);
            }
            if(jumpCount == 2)
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            //rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            jumpCount--;
        }

    }

    public void ShootButton()
    {
        anim.SetBool("isShooting", true);
        Invoke("Shoot", 1.0f);

    }

    public void Shoot()
    {
        anim.SetBool("isShooting", false);


    }

    public void EatButton()
    {
        anim.SetBool("isEating", true);
        //if("먹이"가 콜라이더에 닿으면){
        //invoke("Eat", 0.1f);
        //}else if(아무것도 없으면){
        Invoke("NoEat", 1.0f);
        //}

    }

    public void Eat()
    {
        

    }

    public void NoEat()
    {
        anim.SetBool("isEating", false);
        
    }

    public void OutButton()
    {
        //anim.SetBool("isOutting", true);
        anim.SetBool("isEating", false);
    }
}
