using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMain : MonoBehaviour
{
    //bgm;
    GameObject BackgroundMusic;
    AudioSource backmusic;
    public GameObject canvas;
    public GameObject SettingPanel;
    public GameObject ExitPanel;
    private int canvasChild = 6; // 씬 개수

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
                canvas.transform.GetChild(i).gameObject.SetActive(true);
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
    }

    public void PanelSettingsOff()
    {
        SettingPanel.SetActive(false);
    }

    public void bgmON()
    {
        backmusic.Play();
        //PlayerPrefs.SetInt("mainBGM", 0);
        ////Debug.Log("mainBGM on");
    }

    public void bgmOff()
    {
        backmusic.Pause();
        //PlayerPrefs.SetInt("mainBGM", 1);
    }

}
