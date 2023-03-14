using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score_Frog_Gameover : MonoBehaviour
{
    bool isGameOver;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGameOver = GameObject.Find("Player").GetComponent<ScoreMode_Frog_PlayController_Jump>().isGameOver;
        anim.SetBool("isGameOver", isGameOver);
    }
    public void RePlay()
    {
        SceneManager.LoadScene("InfiniteFrog");
    }

    public void QUIT()
    {
        SceneManager.LoadScene("0_StartScene");
    }
}
