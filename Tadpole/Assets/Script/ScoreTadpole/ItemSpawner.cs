using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject starPrefab;
    [SerializeField]
    private GameObject boosterPrefab;

    [SerializeField]
    public float starInterval = 53f;
    [SerializeField]
    public float boosterInterval = 13f;

    void Start()
    {
        StartCoroutine(spawnItem(starInterval, starPrefab));
        StartCoroutine(spawnItem(boosterInterval, boosterPrefab));
    }

    private IEnumerator spawnItem(float interval, GameObject item)
    {
        yield return new WaitForSeconds(interval);
        GameObject newItem = Instantiate(item, new Vector3(Random.Range(-26f, 26), Random.Range(-10f, 10), 0), Quaternion.identity);
        StartCoroutine(spawnItem(interval + 1, item));
    }
}
