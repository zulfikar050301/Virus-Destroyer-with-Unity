using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerGO : MonoBehaviour
{
    public GameObject EnemyGO; //prefabs musuh

    float maxSpawnRateInSeconds = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //manggil musuh
    void SpawnEnemy()
    {
        //bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //top-right point  of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //manggil musuh
        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //timing untuk manggil musuh
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 5f)
        {
            //pilih  angka dari 1   sampai  maxspawnrateiseconds
            spawnInNSeconds = Random.Range(5f, maxSpawnRateInSeconds);
        }
        else
            spawnInNSeconds = 2f;

        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    //fungsi buat ningkatin kesulitan game
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 2f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 2f)
            CancelInvoke("IncreaseSpawnRate");
    }

    //fungsi untuk memulai memanggil musuh
    public void ScheduleEnemySpawner()
    {
        //reset max spawn rate
        maxSpawnRateInSeconds = 5f;

        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        //increase spawn  rate  every 30 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }
    //fungsi untuk menghentikan memanggil  musuh
    public void UnScheduleEnemySpawner()
    {
        CancelInvoke ("SpawnEnemy");
        CancelInvoke ("IncreaseSpawnRate");
    }
}
