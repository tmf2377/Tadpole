using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTadpole : MonoBehaviour
{
    
    void Start()
    {
        Invoke("playGame", 5f);
    }

    
    void Update()
    {
        
    }

    void playGame()
    {
        SceneManager.LoadScene("InfiniteTedpole");
    }
}
