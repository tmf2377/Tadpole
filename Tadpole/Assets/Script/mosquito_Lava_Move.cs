using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosquito_Lava_Move : MonoBehaviour
{
    Rigidbody2D rigid;      //물리를 받아야 하기에 리지드바디 추가
    public float nextMove_x, time_x;        //행동지표를 결정할 변수, 다시행동하는 시간
    public float nextMove_y, time_y;
    SpriteRenderer spriteRenderer;  //문워크 방지

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //초기화
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        Think_x();
        Think_y();
        Think_tx();
        Think_ty();
    }

    // Update is called once per frame
    void FixedUpdate()      //물리기반이기에 FixedUpdate로 한다
    {
        int temp = 0;
        //Move
        rigid.velocity = new Vector2(nextMove_x, nextMove_y);     
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
            

        //Platform Check
        
        Vector2 Landing = new Vector2(rigid.position.x, rigid.position.y);      //착륙했는가
        Debug.DrawRay(Landing, Vector3.down * 0.1f, new Color(1, 0, 0));
        RaycastHit2D Swim = Physics2D.Raycast(Landing, Vector3.down * 0.1f, 1, LayerMask.GetMask("Platform"));         //자신이 공중에 떴는지 확인
        if (Swim.collider == null)
         {
            //공중에 뜬경우
            rigid.gravityScale = 2;
        }        
        else if (Swim.collider != null)
        {
            //공중이 아닌경우
            rigid.gravityScale = 0.5f; 
        }
        
    }

    //행동지표를 바꿔줄 메서드 //reculsive
    void Think_x()
    {
        nextMove_x = Random.Range(-0.8f, 0.8f);    //랜덤수의 범위
                                             //최소값은 범위에 포함되지만 최대값은 포함되지 않는다
        Invoke("Think_x", time_x);
    }
    void Think_y()
    {        
        nextMove_y = Random.Range(0, 3.5f);
        Invoke("zero_y", 1);
        Invoke("Think_y", time_y);
    }
    void Think_tx()
    {
        //랜덤수의 범위
        //최소값은 범위에 포함되지만 최대값은 포함되지 않는다
        time_x = Random.Range(2, 5);
        Invoke("Think_tx", time_x);
    }
    void Think_ty()
    {
        //랜덤수의 범위
        //최소값은 범위에 포함되지만 최대값은 포함되지 않는다
        time_y = Random.Range(7, 15);
        Invoke("Think_ty", time_y);
    }
    void zero_y()
    {
        nextMove_y = 0;
    }

}
