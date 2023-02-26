using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Frog_Gameover_Score : MonoBehaviour
{
    float finalScore;
    Text scoreText;
    
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        finalScore = GameObject.Find("Player").GetComponent<ScoreMode_Frog_PlayController_Jump>().finalScore;
        scoreText.text = "Score : " + finalScore.ToString();
    
    }
}
