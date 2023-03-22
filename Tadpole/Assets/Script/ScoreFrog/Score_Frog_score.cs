using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score_Frog_score : MonoBehaviour
{
    // Start is called before the first frame update
    public float ScoreTime;
    public Text text_Timer;
    //int temp;

    void Start()
    {
        ScoreTime = 0;
        //temp = 0;
    }

    // Update is called once per frame
    void Update()
    {

        ScoreTime += Time.deltaTime;

        /*
        temp++;
        if(temp % 5 == 0)       //점수증가 속도를 5배 느리게
        {
            //ScoreTime += Time.deltaTime;
            ScoreTime++;
        }*/
        
        text_Timer.text = "" + Mathf.Floor(ScoreTime * 100);
    }
}