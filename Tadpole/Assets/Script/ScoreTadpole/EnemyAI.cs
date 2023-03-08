using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed;
    //public float distanceBetween;

    private float distance;


    public SpriteRenderer enemy;

    //추가작업
    //public float max;
    //Vector2 waypoint;

    void Start()
    {
        enemy = GetComponent<SpriteRenderer>();
        //추가
        //waypoint = new Vector2(Random.Range(-max, max), Random.Range(-max, max));
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        if(angle > -90 && angle < 90)
        {
            enemy.flipY = false;
        }
        else
        {
            enemy.flipY = true;
        }


        /*
        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, waypoint, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }*/

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
