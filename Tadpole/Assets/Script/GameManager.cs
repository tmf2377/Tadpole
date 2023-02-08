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
        else
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

    /*
    public static GameManager instance = null;

    public GameObject menuCam;
	public GameObject gameCam;
	public Boss boss;
	public GameObject itemShop;
	public GameObject weaponShop;
	public GameObject clearPortal;
	public GameObject enemyRespawnZone;
	public int stage;
	public float playTime;
	public bool isBattle;
	public bool isFirstLoad;
	public int enemyCntA;
	public int enemyCntB;
	public int enemyCntC;
	public int enemyCntD;

	public GameObject[] enemyZones;
	public GameObject[] enemies;
	public List<int> enemyList;

	public GameObject menuPanel;
	public GameObject gamePanel;
	public GameObject overPanel;
	public Text maxScoreTxt;
	public Text scoreTxt;
	public Text stageTxt;
	public Text playTimeTxt;
	public Text playerHealthTxt;
	public Text playerAmmoTxt;
	public Text playerCoinTxt;
	public Image weapon1Img;
	public Image weapon2Img;
	public Image weapon3Img;
	public Image weaponRImg;
	public Text enemyATxt;
	public Text enemyBTxt;
	public Text enemyCTxt;
	public RectTransform bossHealthGroup;
	public RectTransform bossHealthBar;

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
        maxScoreTxt.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));
		isFirstLoad = true;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if(!isFirstLoad && SceneManager.GetActiveScene().name == "0_StartStage")
		{
            menuCam = GameObject.FindGameObjectWithTag("MenuCam");
            menuCam.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name != "0_StartStage")
			StageStart();
	}

    private void OnDisable()
    {
		SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void GameStart()
    {
        gameCam.SetActive(true);
        menuCam.SetActive(false);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        Player.instance.gameObject.SetActive(true);
        isFirstLoad = false;
    }

    public void GameOver()
    {
		stage--;
		gamePanel.SetActive(false);
		overPanel.SetActive(true);
    }

	public void Restart()
	{
		SceneManager.LoadScene("0_StartStage");
        gamePanel.SetActive(true);
        overPanel.SetActive(false);
        enemyCntA = 0;
        enemyCntB = 0;
        enemyCntC = 0;
        enemyCntD = 0;
		enemyList.Clear();
        StageEnd();
    }

    public void StageStart()
	{
		isBattle = true;
		stage = SceneManager.GetActiveScene().buildIndex - 1;
		enemyZones = GameObject.FindGameObjectsWithTag("Enemy Zone");
        clearPortal = GameObject.FindGameObjectWithTag("StartZone");
        clearPortal.SetActive(false);
        foreach (GameObject zone in enemyZones)
            zone.SetActive(true);
        StartCoroutine(InBattle());
	}

	public void StageEnd()
	{
		clearPortal.SetActive(true);
        isBattle = false;
        foreach (GameObject zone in enemyZones)
			zone.SetActive(false);
	}

	IEnumerator InBattle()
	{
		for (int index = 0; index < stage * 8; index++)
        {
            int ran = Random.Range(0, 3);
            enemyList.Add(ran);

            switch (ran)
            {
                case 0:
                    enemyCntA++;
                    break;
                case 1:
                    enemyCntB++;
                    break;
                case 2:
                    enemyCntC++;
                    break;
            }
        }

        while (enemyList.Count > 0)
        {
            int ranZone = Random.Range(0, 4);
            GameObject instantEnemy = Instantiate(enemies[enemyList[0]], enemyZones[ranZone].transform.position, enemyZones[ranZone].transform.rotation);
			Debug.Log(enemies[enemyList[0]]);
            Enemy enemy = instantEnemy.GetComponent<Enemy>();
			//enemy.target = player.transform;
            enemy.manager = this;
            enemyList.RemoveAt(0);
			yield return new WaitForSeconds(10f);
        }

        while (enemyCntA + enemyCntB + enemyCntC > 0)
		{
			yield return null;
		}

        if (stage % 3 == 0)
        {
            yield return new WaitForSeconds(3f);
            enemyCntD++;
            GameObject instantEnemy = Instantiate(enemies[3], enemyZones[0].transform.position, enemyZones[0].transform.rotation);
            Enemy enemy = instantEnemy.GetComponent<Enemy>();
            enemy.target = Player.instance.transform;
            enemy.manager = this;
            boss = instantEnemy.GetComponent<Boss>();
        }

        while (enemyCntD > 0)
        {
            yield return null;
        }

        yield return new WaitForSeconds(4f);
		boss = null;
		StageEnd();
	}

	private void Update()
    {
        if (isBattle)
			playTime += Time.deltaTime;
    }

	private void LateUpdate()
    {
        // 상단 UI
        scoreTxt.text = string.Format("{0:n0}", Player.instance.score);
		stageTxt.text = "STAGE " + stage;

		int hour = (int)(playTime / 3600);
		int min = (int)((playTime - hour * 3600) / 60);
		int second = (int)(playTime % 60);
		playTimeTxt.text = string.Format("{0:00}", hour) + ":" + string.Format("{0:00}", min) + ":" + string.Format("{0:00}", second);

		// 플레이어 UI
		playerHealthTxt.text = Player.instance.health + " / " + Player.instance.maxHealth;
		playerCoinTxt.text = string.Format("{0:n0}", Player.instance.coin);
		if (Player.instance.equipWeapon == null)
			playerAmmoTxt.text = "- / " + Player.instance.ammo;
		else if (Player.instance.equipWeapon.type == Weapon.Type.Melee)
			playerAmmoTxt.text = "- / " + Player.instance.ammo;
		else
			playerAmmoTxt.text = Player.instance.equipWeapon.curAmmo + " / " + Player.instance.ammo;

		// 무기 UI
		weapon1Img.color = new Color(1, 1, 1, Player.instance.hasWeapons[0] ? 1 : 0);
		weapon2Img.color = new Color(1, 1, 1, Player.instance.hasWeapons[1] ? 1 : 0);
		weapon3Img.color = new Color(1, 1, 1, Player.instance.hasWeapons[2] ? 1 : 0);
		weaponRImg.color = new Color(1, 1, 1, Player.instance.hasGrenades > 0 ? 1 : 0);

		// 몬스터 숫자 UI
		enemyATxt.text = enemyCntA.ToString();
		enemyBTxt.text = enemyCntB.ToString();
		enemyCTxt.text = enemyCntC.ToString();

		// 보스체력 UI
		if(boss != null && SceneManager.GetActiveScene().name != "0_StartStage")
		{
			bossHealthGroup.anchoredPosition = Vector3.down * 30;
            bossHealthBar.localScale = new Vector3((float)boss.curHealth / boss.maxHealth, 1, 1);
        }
		else
		{
			bossHealthGroup.anchoredPosition = Vector3.up * 200;
		}
	}
	*/
}
