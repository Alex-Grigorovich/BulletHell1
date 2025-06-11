using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner2 : MonoBehaviour
{
    [System.Serializable]
    public class Territory
    {
        public Vector3 center;     // Center position of territory
        public Vector3 size;       // Size of the territory box (width, height, depth)
        
        public Vector3 GetRandomPosition()
        {
            // Random position inside box territory
            float x = Random.Range(center.x - size.x / 2f, center.x + size.x / 2f);
            float y = Random.Range(center.y - size.y / 2f, center.y + size.y / 2f);
            float z = Random.Range(center.z - size.z / 2f, center.z + size.z / 2f);
            return new Vector3(x, y, z);
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int numberOfEnemies = 5;
        public float spawnInterval = 1f;
        public GameObject[] enemyPrefabs;
        public Territory territory;
        public float timeBetweenWaves = 5f;
    }

    public Wave[] waves;

    private int currentWaveIndex = 0;
    private bool spawning = false;

    private void Start()
    {
        if (waves == null || waves.Length == 0)
        {
            Debug.LogError("No waves configured!");
            return;
        }
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < waves.Length)
        {
            Wave currentWave = waves[currentWaveIndex];
            Debug.Log($"Starting Wave {currentWaveIndex + 1} with {currentWave.numberOfEnemies} enemies");

            for (int i = 0; i < currentWave.numberOfEnemies; i++)
            {
                SpawnEnemy(currentWave);
                yield return new WaitForSeconds(currentWave.spawnInterval);
            }

            currentWaveIndex++;

            if (currentWaveIndex < waves.Length)
            {
                Debug.Log($"Wave {currentWaveIndex} finished. Waiting {currentWave.timeBetweenWaves} seconds before next wave.");
                yield return new WaitForSeconds(currentWave.timeBetweenWaves);
            }
        }

        Debug.Log("All waves completed!");
    }

    private void SpawnEnemy(Wave wave)
    {
        if (wave.enemyPrefabs == null || wave.enemyPrefabs.Length == 0)
        {
            Debug.LogWarning("No enemy prefabs assigned for this wave.");
            return;
        }

        // Randomly select enemy prefab from the array
        GameObject enemyPrefab = wave.enemyPrefabs[Random.Range(0, wave.enemyPrefabs.Length)];

        // Get random spawn position inside the territory
        Vector3 spawnPos = wave.territory.GetRandomPosition();

        // Instantiate enemy
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    // Optional: Visualize territories in editor
    private void OnDrawGizmosSelected()
    {
        if (waves == null)
            return;

        Gizmos.color = Color.cyan;
        foreach (var wave in waves)
        {
            if (wave.territory != null)
            {
                Gizmos.DrawWireCube(wave.territory.center, wave.territory.size);
            }
        }
    }
}

