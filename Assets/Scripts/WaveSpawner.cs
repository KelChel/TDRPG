using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

[Serializable]
public class Wave
{
    public List<GameObject> enemyPrefabs;
    public float timeBetweenSpawn;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform spawnpoint;
    public TilemapEraser tilemapEraser;
    public TMP_Text waveCountDownText;
    public float timeBetweenWaves = 15f;
    private float countdown = 3f;
    private int waveIndex = 0;

    private void Start()
    {

    }

    private void Update()
    {
        if (countdown <= 0f && waveIndex < waves.Length)
        {
            StartCoroutine(SpawnWave(waves[waveIndex]));
            countdown = timeBetweenWaves;
            tilemapEraser.StartEraser();
        }

        countdown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave(Wave wave)
    {
        waveIndex++;

        foreach (GameObject enemyPrefab in wave.enemyPrefabs)
        {
            SpawnEnemy(enemyPrefab);
            yield return new WaitForSeconds(wave.timeBetweenSpawn);
        }
        
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
    }
}