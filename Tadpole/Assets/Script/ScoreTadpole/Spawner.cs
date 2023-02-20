using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject fishPrefab;
    [SerializeField]
    private GameObject sharkPrefab;

    [SerializeField]
    private float fishInterval = 3.5f;
    [SerializeField]
    private float sharkInterval = 10f;

    void Start()
    {
        StartCoroutine(spawnEnemy(fishInterval, fishPrefab));
        StartCoroutine(spawnEnemy(sharkInterval, sharkPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-25f, 25), 10, 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
