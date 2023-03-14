using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMain : MonoBehaviour
{
    //bgm;
    //public GameObject BGM;

    //GameObject BackgroundMusic;
    //public AudioSource backmusic;
    public GameObject canvas;
    public GameObject SettingPanel;
    public GameObject ExitPanel;
    private int canvasChild = 6; // 씬 개수


    // 설정 관련 변수
    public GameObject BGAudio;
    public GameObject clickAudio;
    public GameObject viveOb;

    private bool star;


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        BGAudio = GameObject.Find("BGM");
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }




    void Start()
    {
        ExitPanel.SetActive(false);
        SettingPanel.SetActive(false);
        //BackgroundMusic = GameObject.FindGameObjectWithTag("mainBGM");
    }

    // Update is called once per frame
    void Update()
    {
        //안드로이드인 경우
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape)) // 뒤로가기 키 입력
            {
                ExitPanel.SetActive(true);
                int canvasChildCount = canvas.transform.childCount;
                if (canvasChildCount > canvasChild)
                {
                    for (int i = canvasChild; i < canvasChildCount; i++)
                    {
                        canvas.transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public void ExitYes()
    {
        Application.Quit();
    }

    public void ExitNo()
    {

        int canvasChildCount = canvas.transform.childCount;
        if (canvasChildCount > canvasChild)
        {
            for (int i = canvasChild; i < canvasChildCount; i++)
            {
                //canvas.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        ExitPanel.SetActive(false);
    }

    public void buttonExitOn()
    {
        ExitPanel.SetActive(true);
    }

    public void buttonSettingsOn()
    {
        SettingPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void PanelSettingsOff()
    {
        SettingPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void BGAudioOn()
    {
        BGAudio.SetActive(true);
    }

    public void BGAudioOff()
    {
        BGAudio.SetActive(false);
    }

    public void clickAudioOn()
    {
        clickAudio.SetActive(true);
    }

    public void clickAudioOff()
    {
        clickAudio.SetActive(false);
    }

    public void viveOn()
    {
        viveOb.SetActive(true);
    }

    public void viveOff()
    {
        viveOb.SetActive(false);
    }
}
