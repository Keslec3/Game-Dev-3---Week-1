using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints; // Spawn locations
    [SerializeField] float delayBetweenSpawn; // Delay between enemy spawns
    [SerializeField] float delayBetweenWaves; // Delay between waves of enemies
    [SerializeField] GameObject enemyPrefab; // Enemy prefab to spawn
    [SerializeField] EnemyData[] enemiesData; // Enemy data array
    private int currentWaveCount = 0; // Current wave tracker

    public void SpawnerLogic()
    {
        StartCoroutine(SpawnWave()); // Start spawning enemies
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randomInteger = Random.Range(0, spawnPoints.Length); // Random spawn point
            GameObject spawnedShip = Instantiate(enemyPrefab, spawnPoints[randomInteger]); // Spawn enemy
            // Set enemy data for components
            var enemyVisual = spawnedShip.GetComponent<EnemyVisual>();
            var enemyMovement = spawnedShip.GetComponent<EnemyMovement>();
            var enemyLife = spawnedShip.GetComponent<EnemyLife>();
            enemyVisual.enemyData = enemiesData[randomInteger];
            enemyMovement.enemyData = enemiesData[randomInteger];
            enemyLife.enemyData = enemiesData[randomInteger];

            yield return new WaitForSeconds(delayBetweenSpawn); // Wait before next spawn
        }

        currentWaveCount++;
        if (currentWaveCount > enemiesData.Length - 1)
        {
            currentWaveCount = 0; // Reset wave count
        }

        yield return new WaitForSeconds(delayBetweenWaves); // Wait before next wave
        StartCoroutine(SpawnWave()); // Spawn new wave
    }
}
