using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    // Time it takes for each enemy to spawn
    [SerializeField] private float spawnRate = 2.5f;
    // NOTE (donke): Enemy list de do isse
    // Ya to idhr ya editor me
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner ()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        
        while (canSpawn)
        {
            Debug.Log("Spawned");
            yield return wait;
            int randEnemyIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[randEnemyIndex];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
