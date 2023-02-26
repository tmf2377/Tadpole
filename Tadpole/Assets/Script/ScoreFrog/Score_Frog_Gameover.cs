using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score_Frog_Gameover : MonoBehaviour
{
    public void RePlay()
    {
        SceneManager.LoadScene("Frog_intro");
    }

    public void QUIT()
    {
        SceneManager.LoadScene("0_StartScene");
    }
}
