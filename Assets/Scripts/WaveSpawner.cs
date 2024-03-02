using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnpoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 3f;

    public GameObject[] enemy;


    public TMP_Text waveCountDownText;


    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;

        }

        countdown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Round(countdown).ToString();

        if(waveIndex >= 7)
        {
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemy.Length == 0)
            {
                Time.timeScale = 0f;
            }
        }
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            if (waveIndex <= 7)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.4f);
            }
            else
            {
                yield break;
            }
            
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
    }
}
