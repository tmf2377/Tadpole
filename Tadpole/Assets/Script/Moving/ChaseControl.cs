using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseControl : MonoBehaviour
{
    public dragonfly_Move[] enemyArray;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            foreach(dragonfly_Move dm in enemyArray)
            {
                dm.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            foreach(dragonfly_Move dm in enemyArray)
            {
                dm.chase = false;
            }
        }
    }
}


