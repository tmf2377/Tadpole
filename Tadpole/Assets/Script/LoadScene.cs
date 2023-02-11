using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private int currentScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tadpole")
        {
            //씬 이동 시켜라.
            currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(++currentScene);
        }
    }
   
}
