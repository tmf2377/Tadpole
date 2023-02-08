using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criket_Move : MonoBehaviour
{
    Rigidbody2D rigid;      //물리를 받아야 하기에 리지드바디 추가
    BoxCollider2D collider;
    SpriteRenderer spriteRenderer;  //문워크 방지
    public int nextMove;        //행동지표를 결정할 변수
    public int jumpTime;        //점프간격
    public bool isJump = false;
    public float jumpPower;
    float temp;     //움직이는 방향으로 작은 상수
    float box;     //레이케스트 콜라이더에 붙히기

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        jumpPower = 7;
        nextMove = 2;
        temp = 0;
        collider = this.GetComponent<BoxCollider2D>();

        JumpTime();
        Jump();
    }

    private void Update()
    {
        box = collider.size.x / 2;
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);   //이동

        //방향전환
        if (nextMove < 0)
        {
            spriteRenderer.flipX = false; temp = -0.2f;
            box *= -1;
        }
        if (nextMove > 0)
        {
            spriteRenderer.flipX = true; temp = 0.2f;
            box *= 1;
        }

        //점프
        Debug.DrawRay(rigid.position, Vector3.down * 0.5f, new Color(1, 0, 0));
        RaycastHit2D rayHitJump = Physics2D.Raycast(rigid.position, Vector3.down * 0.5f, 1, LayerMask.GetMask("Platform"));
        //rayHit는 여러개 맞더라도 처음 맞은 오브젝트의 정보만을 저장(?) 
        if (rigid.velocity.y < 0)
        { // 뛰어올랐다가 아래로 떨어질 때만 빔을 쏨 
            if (rayHitJump.collider != null)
            { //빔을 맞은 오브젝트가 있을때  -> 맞지않으면 collider도 생성되지않음 
                if (rayHitJump.distance < 0.7f)
                    isJump = false;
            }
        }

        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + box + temp, rigid.position.y);      //x축은 자기 자신의 앞을,y축은 자기 자신을 미리 본다
        Debug.DrawRay(frontVec, Vector3.down * 2, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down * 2, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null && isJump == false)
        {
            nextMove = nextMove * -1;
        }
        //낭떠러지를 만나는 경우 방향을 바꿈


        //막다른길
        Debug.DrawRay(frontVec, Vector3.right * 0.5f, new Color(0, 0, 1));
        RaycastHit2D rayHitBlock = Physics2D.Raycast(frontVec, Vector3.right * 0.5f, 1, LayerMask.GetMask("Platform"));
        if (rayHitBlock.collider != null)
        { //빔을 맞은 오브젝트가 있을때  -> 맞지않으면 collider도 생성되지않음 
            if (rayHitJump.distance < 0.7f)
                nextMove = nextMove * -1;
        }
    }
    void Jump()
    {
        if (!isJump)
        {
            isJump = true;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        Invoke("JumpCheck", 2);     //2초후에도 점프중이라면?
        Invoke("Jump", jumpTime);
    }
    void JumpTime()
    {
        jumpTime = Random.Range(3, 7);

        Invoke("JumpTime", jumpTime);
    }
    void JumpCheck()
    {
        if (isJump == true)      //점프중이라면
        {
            rigid.AddForce(Vector2.down * jumpPower, ForceMode2D.Impulse);  //아래로 힘줌
        }
    }

}