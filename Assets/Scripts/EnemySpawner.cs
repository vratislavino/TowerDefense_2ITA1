using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<EnemyStats> enemyPrefabs;

    [SerializeField]
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        var enemyPrefab = enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Count)];
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
