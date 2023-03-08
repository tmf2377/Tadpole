using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public float ScoreTime;
    public Text text_Timer;

    public float fianlScore;
    
    void Start()
    {
        ScoreTime = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTime += Time.deltaTime;
        fianlScore = Mathf.Round(ScoreTime);
        text_Timer.text = "" + fianlScore;
    }


}
