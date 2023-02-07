using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosquito_Lava_Move : MonoBehaviour
{
    Rigidbody2D rigid;      //물리를 받아야 하기에 리지드바디 추가
    public float nextMove_x, time_x;        //행동지표를 결정할 변수, 다시행동하는 시간
    public float time_y;
    SpriteRenderer spriteRenderer;  //문워크 방지
    public bool isJump = false;
    public float jumpPower;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //초기화
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        isJump = false;
        jumpPower = 6;

        Think_x();
        Think_tx();
        Think_ty();
        Jump();
    }

    // Update is called once per frame
    void FixedUpdate()      //물리기반이기에 FixedUpdate로 한다
    {
        int temp = 0;
        //Move
        rigid.velocity = new Vector2(nextMove_x, rigid.velocity.y);     
        //방향전환
        if (nextMove_x < 0)
        {
            spriteRenderer.flipX = false;
            temp = -1;
        }        
        else if (nextMove_x > 0)
        {
            spriteRenderer.flipX = true;
            temp = 1;
        }


        //점프
        Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 0));
        RaycastHit2D rayHitJump = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
        //rayHit는 여러개 맞더라도 처음 맞은 오브젝트의 정보만을 저장(?) 
        if (rigid.velocity.y < 0)
        { // 뛰어올랐다가 아래로 떨어질 때만 빔을 쏨 
            if (rayHitJump.collider != null)
            { //빔을 맞은 오브젝트가 있을때  -> 맞지않으면 collider도 생성되지않음 
                if (rayHitJump.distance < 0.7f)
                    isJump = false;
            }
        }

    }

    //행동지표를 바꿔줄 메서드 //reculsive
    void Think_x()
    {
        nextMove_x = Random.Range(-0.8f, 0.8f);    
        Invoke("Think_x", time_x);
    }   
    //x축 움직임의 랜덤값
    void Think_tx()
    {
        //랜덤수의 범위
        //최소값은 범위에 포함되지만 최대값은 포함되지 않는다
        time_x = Random.Range(2, 5);
        Invoke("Think_tx", time_x);
    }
    //x축 움직임을 결정하는 시간 랜덤
    void Think_ty()
    {
        time_y = Random.Range(7, 15);
        Invoke("Think_ty", time_y);
    }
    //점프하는 시간 랜덤
    void Jump()
    {
        if (!isJump)
        {
            isJump = true;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        Invoke("Jump", time_y);
    }
    //점프
}
