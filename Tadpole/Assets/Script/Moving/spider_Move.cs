using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_Move : MonoBehaviour
{
    Rigidbody2D rigid;      //물리를 받아야 하기에 리지드바디 추가
    Collider2D collider;
    public int nextMove;        //행동지표를 결정할 변수 
    SpriteRenderer spriteRenderer;  //문워크 방지
    float temp; //좁은 땅 도리도리 방지

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //초기화
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        collider = this.GetComponent< >
        Think();
    }

    // Update is called once per frame
    void FixedUpdate()      //물리기반이기에 FixedUpdate로 한다
    {
        //Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);     //왼쪽으로만 움직이는 경우 x축은 -1, y축 은 현재의 값
                                                                      //nextMove를 통해 x축을 랜덤으로 결정

        //방향전환
        if (nextMove < 0)
        {
            spriteRenderer.flipX = false; temp = -0.5f;
        }
        if (nextMove > 0)
        {
            spriteRenderer.flipX = true; temp = 0.5f;
        }


        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + temp, rigid.position.y);      //x축은 자기 자신의 앞을,y축은 자기 자신을 미리 본다
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            nextMove = nextMove * -1;
            CancelInvoke();     //작동중인 Invoke가 멈춤
            Invoke("Think", 5);     //5초를 다시 셈
        }
        //낭떠러지를 만나는 경우 방향을 바꿈
    }

    //행동지표를 바꿔줄 메서드 //reculsive
    void Think()
    {
        int Criteria = Random.Range(-5, 6);    
        if(Criteria < 0)
        {
            nextMove = -5;
        }
        else
        {
            nextMove = 5;
        }

        Invoke("Think", 5);
    }
}
