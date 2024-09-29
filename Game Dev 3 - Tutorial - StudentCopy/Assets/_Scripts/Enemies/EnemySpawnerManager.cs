using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float delayBetweenSpawn;
    [SerializeField] int numberOfEnemySpawned;
    [SerializeField] float delayBetweenWaves;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] EnemyData[] enemiesData;
    [SerializeField] int wavesNumber;
    private int currentWaveCount = 0;



    public void SpawnerLogic()
    {
        StartCoroutine(SpawnWave());
    }
    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randomInteger = Random.Range(0, spawnPoints.Length - 1);
            GameObject spawnedShip = Instantiate(enemyPrefab, spawnPoints[randomInteger]);
            spawnedShip.GetComponent<EnemyVisual>().enemyData = enemiesData[randomInteger];
            spawnedShip.GetComponent<EnemyMovement>().enemyData = enemiesData[randomInteger];
            spawnedShip.GetComponent<EnemyLife>().enemyData = enemiesData[randomInteger];
            yield return new WaitForSeconds(delayBetweenSpawn);

        }

        currentWaveCount++;
        if(currentWaveCount > enemiesData.Length - 1)
        {
            currentWaveCount = 0;
        }

        yield return new WaitForSeconds(delayBetweenWaves);
        StartCoroutine(SpawnWave());
    }
    
}
