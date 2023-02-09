using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFrogMode : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("InfiniteFrog");
    }
}
