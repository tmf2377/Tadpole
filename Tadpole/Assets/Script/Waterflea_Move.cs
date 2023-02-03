using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterflea_Move : MonoBehaviour
{
    Rigidbody2D rigid;      //물리를 받아야 하기에 리지드바디 추가
    public float nextMove_x;
    public float nextMove_y;    //행동지표를 결정할 변수     
    SpriteRenderer spriteRenderer;  //문워크 방지

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //초기화
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        nextMove_y = 1;
        nextMove_x = 0.5f;
        Think_y();
    }

    // Update is called once per frame
    void FixedUpdate()      //물리기반이기에 FixedUpdate로 한다
    {
        float temp = 0;
        //Move
        rigid.velocity = new Vector2(nextMove_x, nextMove_y);    

        //방향전환
        if (nextMove_x < 0)
        {
            spriteRenderer.flipX = false;
            temp = rigid.position.x + nextMove_x - 1;
        }           
        if (nextMove_x > 0)
        {
            spriteRenderer.flipX = true;
            temp = rigid.position.x + nextMove_x;            
        }
            

        

        //Platform Check
         Vector2 frontVec = new Vector2(temp, rigid.position.y);      //x축은 자기 자신의 앞을,y축은 자기 자신을 미리 본다
         Debug.DrawRay(frontVec, Vector3.right, new Color(0, 1, 0));
         RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.right, 1, LayerMask.GetMask("Platform"));
         if(rayHit.collider != null)
         {
             nextMove_x = nextMove_x * -1;
             nextMove_y = nextMove_y * -1;
            Invoke("Think_y", 3);
         }
    }

    void Think_y()
    {
        float temp = Random.Range(1f, 2f);
        if(nextMove_y > 0)
        {
            nextMove_y = Random.Range(-0.85f, 0);
        }
        else if (nextMove_y < 0)
        {
            nextMove_y = Random.Range(0, 0.85f);
        }
        //nextMove_y *= -1;
        Invoke("Think_y", temp);
    }


}
