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
    public GameObject endGame;

    private float countdown = 3f;
    private int waveIndex = 0;

    private void Start()
    {
        StartCoroutine(StartTilemapEraser(countdown));
    }

    private void Update()
    {
        if (countdown <= 0f && waveIndex < waves.Length)
        {
            StartCoroutine(SpawnWave(waves[waveIndex]));
            countdown = timeBetweenWaves;
            
        }

        countdown -= Time.deltaTime;

        

        if (waveIndex >= waves.Length)
        {
            waveCountDownText.text = "";
            if (AllEnemiesDefeated()) {
                endGame.SetActive(true);
                Time.timeScale = 0f;
            }
            
        }
        else
        {
            waveCountDownText.text = Mathf.Round(countdown).ToString();
        }
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

    bool AllEnemiesDefeated()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null) // Проверяем, жив ли враг
                return false; // Если хотя бы один враг жив, возвращаем false
        }
        return true; // Если все враги уничтожены, возвращаем true
    }

    IEnumerator StartTilemapEraser(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        tilemapEraser.StartEraser();
    }
}