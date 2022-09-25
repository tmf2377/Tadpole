using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene5to6 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tadpole")

        {
            //씬 이동 시켜라.
            SceneManager.LoadScene("6_StoryScene");
        }
    }
}
