using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Networking;

public class TadpoleAction : MonoBehaviour
{
    [SerializeField]
    private VirtualJoystick virtualJoystick;
    public float moveSpeed = 4.5f;
    AudioSource walkAudio;
    SpriteRenderer spriteRenderer;

    private Rigidbody2D rigid2D;

    public GameObject gameOverPanel;

    public void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        walkAudio = GetComponent<AudioSource>();
    }


    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();

        if (x != 0 || y != 0)
        {
            //transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
            rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;

            // 걸을때 소리
            //if (!walkAudio.isPlaying)
            //    walkAudio.Play();
        }
        else
        {
            //walkAudio.Stop();
        }

        //방향전환
        if (x < 0)
            spriteRenderer.flipX = true;
        if (x > 0)
            spriteRenderer.flipX = false;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("Tedpole_intro");
    }

    public void GoMain()
    {
        SceneManager.LoadScene("0_StartScene");
    }
}
