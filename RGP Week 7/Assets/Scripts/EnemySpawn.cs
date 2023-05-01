using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3 spawnPoint;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 15f, 15f);
    }

    void SpawnEnemy()
    {
        if (GameObject.FindObjectOfType<Enemy>() == null)
        {
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
