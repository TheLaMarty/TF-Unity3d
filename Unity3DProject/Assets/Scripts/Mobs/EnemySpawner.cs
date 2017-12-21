using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public int spawnerSize;
    List<GameObject> enemies;
    public float timeBetweenSpawns;
    public static EnemySpawner SharedInstance;
    public Vector3 spawnValues;
    Vector3 playerPosition;

    int enemiesRemainingToSpawn;
    float nextSpawnTime;
    float playerRange;

    private void Awake()
    {
        SharedInstance = this;
        enemies = new List<GameObject>();
        for (int i = 0; i < spawnerSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(prefab);
            obj.gameObject.SetActive(false);
            enemies.Add(prefab);
        }
    }

    void Start()
    {
        enemiesRemainingToSpawn = spawnerSize;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerRange = 50;
    }

    void FixedUpdate()
    {
        //SpawnAtRandomLocation();

        SpawnEnemies();
        /* if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
         {
             enemiesRemainingToSpawn--;
             nextSpawnTime = Time.time + timeBetweenSpawns;

             //GameObject spawnedEnemy = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
             GameObject spawnedEnemy = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
         }*/
    }

    void SpawnAtRandomLocation()
    {
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + timeBetweenSpawns;

            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), 1, UnityEngine.Random.Range(-spawnValues.z, spawnValues.z));
            /*if ((spawnPosition - playerPosition).magnitude < playerRange)
            {
                GameObject spawnedEnemy = (GameObject)Instantiate(prefab, spawnPosition + transform.TransformPoint(0, 0, 0), Quaternion.identity);
            }*/
            GameObject spawnedEnemy = (GameObject)Instantiate(prefab, spawnPosition + transform.TransformPoint(0, 0, 0), Quaternion.identity);

        }
    }

    private void SpawnEnemies()
    {
        /*
        foreach (GameObject e in enemies)
        {
            Instantiate(e);

        }*/
        foreach (GameObject e in enemies)
        {
            if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
            {
                enemiesRemainingToSpawn--;
                nextSpawnTime = Time.time + timeBetweenSpawns;

                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), 1, UnityEngine.Random.Range(-spawnValues.z, spawnValues.z));
                if ((spawnPosition - playerPosition).magnitude < playerRange)
                {
                    GameObject SpawnedEnemy = (GameObject)Instantiate(prefab, spawnPosition + transform.TransformPoint(0, 0, 0), Quaternion.identity);
                }
                else
                {
                    GameObject spawnedEnemy = (GameObject)Instantiate(prefab, spawnPosition + transform.TransformPoint(0, 0, 0), Quaternion.identity);
                }
            }
        }
    }
}
