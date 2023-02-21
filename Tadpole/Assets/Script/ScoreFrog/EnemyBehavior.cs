using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;
    Animator anim;
    BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent <BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(speed, 0);      // 그 고도에서 비행
        if(this.rigid.position.x > 14 || this.rigid.position.x < -13)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 23)
        {
            anim.SetBool("isStepped", true);
            box.size = new Vector2(0, 0);
            this.speed = -2f;
            Invoke("Delete", 0.7f);
        }
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
