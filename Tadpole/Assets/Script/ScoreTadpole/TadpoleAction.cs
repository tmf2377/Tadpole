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

    //AudioSource walkAudio;
    SpriteRenderer spriteRenderer;

    private Rigidbody2D rigid2D;
    Animator anim;

    public GameObject gameOverPanel;
    public bool isStar;
    private float starTime;

    public GameObject BGM;
    public GameObject starBGM;

    public void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        //walkAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }


    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        gameOverPanel.SetActive(false);
        isStar = false;
        starTime = 47f;
    }

    private void Update()
    {
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();

        if (x != 0 || y != 0)
        {
            //transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
            rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;

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
            if(isStar == false)
            {
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
            }
        }

        if (collision.gameObject.tag == "starItem")
        {
            isStar = true;
            anim.SetBool("isStar", true);
            Invoke("StarEnd", 9f);
            starTime += 7f;
            GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().starInterval = starTime;
            starBGM.SetActive(true);
            BGM.SetActive(false);
            GameObject.Find("Game Manager").GetComponent<StartMain>().BGAudio = GameObject.Find("starBGM");
            

        }

        if (collision.gameObject.tag == "boosterItem")
        {
            moveSpeed = 9f;
            Invoke("BoosterEnd", 4f);
        }
    }

    private void BoosterEnd()
    {
        moveSpeed = 4.5f;
    }

    private void StarEnd()
    {
        anim.SetBool("isStar", false);
        isStar = false;
        BGM.SetActive(true);
        starBGM.SetActive(false);
        GameObject.Find("Game Manager").GetComponent<StartMain>().BGAudio = GameObject.Find("BGM");
    }

    public void Replay()
    {
        SceneManager.LoadScene("InfiniteTedpole");
        Time.timeScale = 1;
    }

    public void GoMain()
    {
        SceneManager.LoadScene("0_StartScene");
        Time.timeScale = 1;
    }
}
