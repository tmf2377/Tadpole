using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMode_Frog_Camera : MonoBehaviour
{
    public static ScoreMode_Frog_Camera instance = null;
    // Start is called before the first frame update
    public Transform target;
    public float speed;
    float score;            //현재게임의 스코어
    public Gradient camera_background;
    Camera camera;
    // Update is called once per frame

    public Vector2 center;  //제한된 영역의 중심점
    public Vector2 size;    //제한된 영역의 크기
    float height;
    float width;
    float backgroundTrriger;
    void Start()
    {
        height = Camera.main.orthographicSize;  //세로의 절반크기
        width = height * Screen.width / Screen.height;  //가로 = 세로 * 스크린 가로 / 스크린 세로
        camera = GetComponent<Camera>();
        score = GameObject.Find("Score").GetComponent<score>().ScoreTime;
        backgroundTrriger = 0;
        BackgroundTrrigerIncrease();
    }
    private void Update()
    {
        camera.backgroundColor = camera_background.Evaluate(backgroundTrriger);
    }

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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;           //gizmo 색상 빨강
        Gizmos.DrawWireCube(center, size);  //center를 중심으로 한 size크기의 큐브 표시 
    }
    void LateUpdate()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

        float lx = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = size.y * 0.5f - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

    //초마다 0.0125씩 증가 -> 총 80초 후 1에 도달
    //1이상이 되면 1을 빼며 다시 0부터 -> 80초에 1cycle
    void BackgroundTrrigerIncrease()
    {
        if (backgroundTrriger >= 1)
            backgroundTrriger -= 1;
        backgroundTrriger += 0.0125f;
        Invoke("BackgroundTrrigerIncrease", 1);
    }
}
