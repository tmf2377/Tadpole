using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongAnchovy_Move : MonoBehaviour
{
    Rigidbody2D rigid;      //물리를 받아야 하기에 리지드바디 추가
    public int nextMove_x, time;        //행동지표를 결정할 변수, 다시행동하는 시간
    public float nextMove_y;
    SpriteRenderer spriteRenderer;  //문워크 방지

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //초기화
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        //주어진 시간이 지난 뒤 지정된 함수를 실행 : Invoke()
        //Invoke("Think_x", 3); // 3초마다  Think() 실행
        Think_x();
        Think_y();
        Think_t();
    }

    // Update is called once per frame
    void FixedUpdate()      //물리기반이기에 FixedUpdate로 한다
    {
        //Move
        rigid.velocity = new Vector2(nextMove_x, nextMove_y);     //왼쪽으로만 움직이는 경우 x축은 -1, y축 은 현재의 값
                                                                  //nextMove를 통해 x축을 랜덤으로 결정

        //방향전환
        if (nextMove_x < 0)
            spriteRenderer.flipX = false;
        if (nextMove_x > 0)
            spriteRenderer.flipX = true;

       
    }

    //행동지표를 바꿔줄 메서드 //reculsive
    void Think_x()
    {
        nextMove_x = Random.Range(-2, 3);    //랜덤수의 범위
                                             //최소값은 범위에 포함되지만 최대값은 포함되지 않는다
        Invoke("Think_x", time);
    }
    void Think_y()
    {
        //랜덤수의 범위
        //최소값은 범위에 포함되지만 최대값은 포함되지 않는다
        nextMove_y = Random.Range(-1.0f, 1.5f);
        Invoke("Think_y", time);
    }
    void Think_t()
    {
        //랜덤수의 범위
        //최소값은 범위에 포함되지만 최대값은 포함되지 않는다
        time = Random.Range(1, 3);
        Invoke("Think_t", time);
    }
}