using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance = null;
    // Start is called before the first frame update
    public Transform target;
    public float speed;
    // Update is called once per frame

    public Vector2 center;  //제한된 영역의 중심점
    public Vector2 size;    //제한된 영역의 크기
    float height;
    float width;
    void Start()
    {
        height = Camera.main.orthographicSize;  //세로의 절반크기
        width = height * Screen.width / Screen.height;  //가로 = 세로 * 스크린 가로 / 스크린 세로
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
}
