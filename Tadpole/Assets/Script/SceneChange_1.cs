using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange_1 : MonoBehaviour
{
    public void StoryScene()
    {
        SceneManager.LoadScene("1_StoryScene");
    }


    public void TadpoleScene()
    {
        SceneManager.LoadScene("InfiniteTedpole");
    }

    public void FrogScene()
    {
        SceneManager.LoadScene("Frog_intro");
    }
}
