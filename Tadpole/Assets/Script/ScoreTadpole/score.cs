using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public float ScoreTime;
    public Text text_Timer;
    
    void Start()
    {
        ScoreTime = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTime += Time.deltaTime;
        text_Timer.text = "" + Mathf.Round(ScoreTime);
    }
}
