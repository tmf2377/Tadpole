using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMode_Frog_PlayController_Jump : MonoBehaviour
{
   
    public Rigidbody2D rigid;
    public float currentHealth;
    SpriteRenderer spriteRenderer;
    GameManager gameManager;
    Animator anim;
    public float jumpPower;
    bool left,right;
    int ScoreMode_Frog_Enemy, Player;   //NPC와 Player의 Layer 번호

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        jumpPower = 10;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        ScoreMode_Frog_Enemy = LayerMask.NameToLayer("ScoreMode_Frog_Enemy");
        Player = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(ScoreMode_Frog_Enemy, Player, false);    //NPC와 Player는 충돌한다
    }

    // Update is called once per frame
    void Update()
    {
        left = GameObject.Find("Left").GetComponent<ScoreMode_Frog_PlayerController_LeftRight>().isPressed;     //좌클릭
        right = GameObject.Find("Right").GetComponent<ScoreMode_Frog_PlayerController_LeftRight>().isPressed;   //우클릭
        currentHealth = GameObject.Find("HealthBar").GetComponent<HealthBar>().slider.value;                        //현재 체력

        if (left)
            spriteRenderer.flipX = true;
        if (right)
            spriteRenderer.flipX = false;

        if(currentHealth == 0)      //피가 다 달면
        {
            Physics2D.IgnoreLayerCollision(ScoreMode_Frog_Enemy, Player, true);    //떨어지며 충돌무시
        }
        else if(currentHealth != 0)     //떨어지는 도중에라도 하트를 먹으면
        {
            Physics2D.IgnoreLayerCollision(ScoreMode_Frog_Enemy, Player, false);    //NPC와 Player는 충돌한다
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ScoreMode_Frog_Enemy")
        {
            //rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            rigid.velocity = new Vector2(0, jumpPower);
            anim.SetBool("isJump", true);
            Invoke("isJumpFalse", 1);
        }
    }

    void isJumpFalse()
    {
        anim.SetBool("isJump", false);
    }
}
