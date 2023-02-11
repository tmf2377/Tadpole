using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMode_Frog_PlayController_Jump : MonoBehaviour
{
   
    public Rigidbody2D rigid;
    public float jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        jumpPower = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ScoreMode_Frog_Enemy")
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Debug.Log("Ads");
        }
    }
}
