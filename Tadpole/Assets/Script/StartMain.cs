using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMain : MonoBehaviour
{

    public GameObject canvas;
    public GameObject SettingPanel;
    public GameObject ExitPanel;
    private int canvasChild = 6; // 씬 개수


    // 설정 관련 변수
    public GameObject BGM1;
    public GameObject BGM2;
    public GameObject clickAudio;
    public GameObject overSound;
    public GameObject EFS1;
    public GameObject EFS2;
    public GameObject viveOb;

    private bool isstar;


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        BGM1 = GameObject.Find("BGM1");
        BGM2 = GameObject.Find("BGM2");
        overSound = GameObject.Find("OverSound");
        EFS1 = GameObject.Find("EFS1");
        EFS2 = GameObject.Find("EFS2");
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }




    void Start()
    {
        ExitPanel.SetActive(false);
        SettingPanel.SetActive(false);

        EFS1 = null;
        EFS2 = null;
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
        BGM1.SetActive(true);
        BGM2.SetActive(true);
    }

    public void BGAudioOff()
    {
        BGM1.SetActive(false);
        BGM2.SetActive(false);
    }

    public void clickAudioOn()
    {
        clickAudio.SetActive(true);
        overSound.SetActive(true);
        EFS1.SetActive(true);
        EFS2.SetActive(true);
    }

    public void clickAudioOff()
    {
        clickAudio.SetActive(false);
        overSound.SetActive(false);
        EFS1.SetActive(false);
        EFS2.SetActive(false);
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
