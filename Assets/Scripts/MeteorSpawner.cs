using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;
    public float spawnXLimit = 6f;

    private float t = 0f; 

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        float random = Random.Range(-spawnXLimit, spawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

        Invoke("Spawn", Mathf.Lerp(maxSpawnDelay, minSpawnDelay, t));
        Debug.Log("t is: " + t + "\n" + Mathf.Lerp(maxSpawnDelay, minSpawnDelay, t));
        t += Time.deltaTime * 10;
    }

}
