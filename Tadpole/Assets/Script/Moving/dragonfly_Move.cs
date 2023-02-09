using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonfly_Move : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;
    SpriteRenderer spriteRenderer;  //문워크 방지
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        speed = -3;
        
        Flying();
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null)
            return;

        if (chase == true)
        {
            Chase();
        }           
        else if (chase == false)
        {
            if(rigid.transform.position.y < startingPoint.transform.position.y)         //startingPoint 보다 고도가 낮은경우 
            {
                rigid.velocity = new Vector2(speed, startingPoint.position.y);      //고도 회복하며 비행
            }
            else if(rigid.transform.position.y >= startingPoint.transform.position.y)       //고도가 충분한 경우
            {
                rigid.velocity = new Vector2(speed, 0);      // 그 고도에서 비행
            }
            
            if (speed < 0)
            {
                spriteRenderer.flipX = false;
            }
            if (speed > 0)
            {
                spriteRenderer.flipX = true;
            }
        }

        

    }

    private void Chase()
    {
        float num = speed;
        if (num < 0)
        {
            num *= -1;
        }
        Flip();
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, num * Time.deltaTime);
        if (Vector2.Distance(transform.position, player.transform.position) <= 0.5f)
        {
            //부딪혔을때
        }
        else
        {
            //reset variable
        }
       
    }
    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);

    }
    public void Flying()
    {
        speed *= -1;
        Invoke("Flying", 7);
    }
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }
}
