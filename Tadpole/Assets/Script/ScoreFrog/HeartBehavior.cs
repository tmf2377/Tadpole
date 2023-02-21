using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehavior : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(speed, 0);      // 그 고도에서 비행
        if (this.rigid.position.x > 14 || this.rigid.position.x < -13)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 23)
        {
            GameObject.Find("HealthBar").GetComponent<HealthBar>().getHealth();           //현재 체력증가
            Destroy(gameObject);
        }
    }
}
