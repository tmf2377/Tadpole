using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMode_Frog_PlayController_Jump : MonoBehaviour
{
   
    public Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    public float jumpPower;
    bool left,right;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        jumpPower = 10;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        left = GameObject.Find("Left").GetComponent<ScoreMode_Frog_PlayerController_LeftRight>().isPressed;
        right = GameObject.Find("Right").GetComponent<ScoreMode_Frog_PlayerController_LeftRight>().isPressed;
        if (left)
            spriteRenderer.flipX = true;
        if (right)
            spriteRenderer.flipX = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ScoreMode_Frog_Enemy")
        {
            //rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            rigid.velocity = new Vector2(0, jumpPower);
        }
    }
}
