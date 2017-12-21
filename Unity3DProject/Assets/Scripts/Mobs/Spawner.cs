using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawner : MonoBehaviour {

    public Wave[] waves;
    public GameObject enemy;

    int enemiesRemainingToSpawn;
    float nextSpawnTime;

    Wave currentWave;
    int currentWaveNumber;

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }

    void Start () {
        nextWave();
	}
	
	void Update () {
		
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            GameObject spawnedEnemy = (GameObject)Instantiate(enemy, Vector3.zero, Quaternion.identity);
        }
	}

    void nextWave()
    {
        currentWaveNumber++;
        currentWave = waves[currentWaveNumber - 1];

        enemiesRemainingToSpawn = currentWave.enemyCount;
    }

}
