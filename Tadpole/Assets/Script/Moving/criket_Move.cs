using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criket_Move : MonoBehaviour
{
    Rigidbody2D rigid;      //물리를 받아야 하기에 리지드바디 추가
    SpriteRenderer spriteRenderer;  //문워크 방지
    public int nextMove;        //행동지표를 결정할 변수
    public bool isJump = false;
    public float jumpPower;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        jumpPower = 5;
        nextMove = 3;
        
        Jump();
    }

    private void Update()
    {
        //이동
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        //방향전환
        if (nextMove < 0)
            spriteRenderer.flipX = false;
        if (nextMove > 0)
            spriteRenderer.flipX = true;

        Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 0));

        RaycastHit2D rayHitJump = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
        //빔의 시작위치, 빔의 방향 , 1:distance , ( 빔에 맞은 오브젝트를 특정 레이어로 한정 지어야할 때 사용 ) // RaycastHit2D : Ray에 닿은 오브젝트 클래스 

        //rayHit는 여러개 맞더라도 처음 맞은 오브젝트의 정보만을 저장(?) 
        if (rigid.velocity.y < 0)
        { // 뛰어올랐다가 아래로 떨어질 때만 빔을 쏨 
            if (rayHitJump.collider != null)
            { //빔을 맞은 오브젝트가 있을때  -> 맞지않으면 collider도 생성되지않음 
                if (rayHitJump.distance < 0.5f)
                    isJump = false;
            }
        }

        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + (nextMove / 2), rigid.position.y);      //x축은 자기 자신의 앞을,y축은 자기 자신을 미리 본다
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null && isJump == false)
        {
            nextMove = nextMove * -1;           
        }
        //낭떠러지를 만나는 경우 방향을 바꿈
    }
    void Jump()
    {
        if(!isJump)
        {
            isJump = true;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);            
        }        
        Invoke("Jump", 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            isJump = false;
        }
    }    
}
