using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene4to5 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tadpole")

        {
            //씬 이동 시켜라.
            SceneManager.LoadScene("5_StoryScene");
        }
    }
}
