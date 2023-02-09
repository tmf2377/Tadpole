using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScoreMode : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("SelectScene");
    }
   
}
