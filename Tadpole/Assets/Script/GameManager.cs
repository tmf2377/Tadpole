using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Sockets;

public class GameManager : MonoBehaviour
{
    // GameManager
    public static GameManager instance = null;
    
    // Don't Destroy 관련 변수
    public bool isFirstLoad;
    public bool IsTadpole;
    public bool IsFrog;

    // stage 관련 변수
    public int stage;
    private int activeScene;

    // 어,, 그냥 일단 가져옴
    public GameObject[] enemies;
    public List<int> enemyList;

    public GameObject tadpole;
    public GameObject frog;

    // UI 관련 변수
    public GameObject tadpoleCam;
    public GameObject frogCam;

    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject scoreSelectPanel;
    public GameObject overPanal;
    public RectTransform playerHealthGroup;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
        enemyList = new List<int>();
        //maxScoreTxt.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));
        isFirstLoad = true;

        IsTadpole = false;
        IsFrog = false;

        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        scoreSelectPanel.SetActive(false);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
        // 해당 씬에 맞게 올챙이/개구리를 on/off
        // (씬 로드 시) 씬에 있는 카메라에 플레이어 할당
        if (activeScene == 0)
        {
            tadpoleCam.SetActive(false);
            frogCam.SetActive(false);

            tadpole.SetActive(false);
            frog.SetActive(false);
        }
        else if(activeScene < 5)
        {
            tadpoleCam.SetActive(true);
            frogCam.SetActive(false);

            tadpole.SetActive(true);
            frog.SetActive(false);


        }
        else if(activeScene < 25)
        {
            tadpoleCam.SetActive(false);
            frogCam.SetActive(true);

            tadpole.SetActive(false);
            frog.SetActive(true);

        }


        if (!isFirstLoad && SceneManager.GetActiveScene().name == "0_StartScene")
        {
            //menuCam = GameObject.FindGameObjectWithTag("MenuCam");
            //menuCam.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name != "0_StartScene")
            StageStart();

        // (씬 로드 시) 씬에 있는 카메라에 플레이어 할당

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void GameStart()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        //Player.instance.gameObject.SetActive(true);
        isFirstLoad = false;
    }

    public void StageStart()
    {
        stage = SceneManager.GetActiveScene().buildIndex - 1;


        // 스테이지에 따른 올챙이 or 개구리 코드
        //if (stage < 4){
        //  IsTadpole = true;
        //  IsFrog = false;
        //}else{
        //  IsTadpole = false;
        //  IsFrog = true;
        //}


        //clearPortal = GameObject.FindGameObjectWithTag("StartZone");
        //clearPortal.SetActive(false);
    }

    public void ScoreBtn()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        scoreSelectPanel.SetActive(true);
    }

    public void ScoreBackBtn()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        scoreSelectPanel.SetActive(false);
    }

    public void ScoreStart()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        scoreSelectPanel.SetActive(false);
    }
}
