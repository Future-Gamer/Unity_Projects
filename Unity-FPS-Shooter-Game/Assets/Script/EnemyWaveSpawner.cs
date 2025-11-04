using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyWaveSpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject redPrefab;
    public GameObject greenPrefab;
    public GameObject bluePrefab;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    [Header("UI & Animation")]
    public TextMeshProUGUI waveName;
    public Animator animator;

    private int totalRed = 15;
    private int totalGreen = 10;
    private int totalBlue = 5;

    private int remainingRed;
    private int remainingGreen;
    private int remainingBlue;

    private int currentWave = 0;
    private int enemiesToSpawnPerWave = 10;
    private int enemiesSpawnedThisWave = 0;
    private int enemiesAliveThisWave = 0;

    private float sphereSpawnTimer = 0f;
    private float sphereSpawnInterval = 5f;

    private GameObject currentRandomEnemyType;
    private float randomEnemyTypeTimer = 0f;
    private float randomEnemyTypeInterval = 5f;

    private bool isSpawningWave = false; // <--- NEW FLAG

    private void Start()
    {
        remainingRed = totalRed;
        remainingGreen = totalGreen;
        remainingBlue = totalBlue;
        PickNewRandomEnemyType();
        StartWave();
    }

    private void Update()
    {
        // Handle extra sphere spawn every 5 seconds
        sphereSpawnTimer += Time.deltaTime;
        if (sphereSpawnTimer >= sphereSpawnInterval)
        {
            SpawnExtraSphere();
            sphereSpawnTimer = 0f;
        }

        // Update the random enemy type every 5 seconds
        randomEnemyTypeTimer += Time.deltaTime;
        if (randomEnemyTypeTimer >= randomEnemyTypeInterval)
        {
            PickNewRandomEnemyType();
            randomEnemyTypeTimer = 0f;
        }

        // Check if all enemies in the current wave are destroyed
        enemiesAliveThisWave = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (!isSpawningWave && enemiesAliveThisWave == 0 && enemiesSpawnedThisWave == enemiesToSpawnPerWave)
        {
            if (currentWave < 2)
            {
                currentWave++;
                animator.SetTrigger("WaveComplete");
                waveName.text = $"Wave {currentWave + 1}";
                StartWave();
            }
            else
            {
                GameOver();
            }
        }
    }

    private void StartWave()
    {
        isSpawningWave = true;
        enemiesSpawnedThisWave = 0;
        waveName.text = $"Wave {currentWave + 1}";
        StartCoroutine(SpawnWaveCoroutine());
    }

    private IEnumerator SpawnWaveCoroutine()
    {
        while (enemiesSpawnedThisWave < enemiesToSpawnPerWave)
        {
            SpawnRandomEnemy();
            enemiesSpawnedThisWave++;
            yield return new WaitForSeconds(2f); // spawn interval between enemies
        }
        isSpawningWave = false; // <--- STOP SPAWNING UNTIL WAVE IS CLEARED
    }

    private void SpawnRandomEnemy()
    {
        // Use the current random enemy type for this 5-second interval
        GameObject chosenPrefab = currentRandomEnemyType;

        // If the chosen type is not available, pick another available type
        if ((chosenPrefab == redPrefab && remainingRed <= 0) ||
            (chosenPrefab == greenPrefab && remainingGreen <= 0) ||
            (chosenPrefab == bluePrefab && remainingBlue <= 0))
        {
            List<GameObject> availableTypes = new List<GameObject>();
            if (remainingRed > 0) availableTypes.Add(redPrefab);
            if (remainingGreen > 0) availableTypes.Add(greenPrefab);
            if (remainingBlue > 0) availableTypes.Add(bluePrefab);

            if (availableTypes.Count == 0) return;
            chosenPrefab = availableTypes[Random.Range(0, availableTypes.Count)];
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(chosenPrefab, spawnPoint.position, Quaternion.identity);

        if (chosenPrefab == redPrefab) remainingRed--;
        else if (chosenPrefab == greenPrefab) remainingGreen--;
        else if (chosenPrefab == bluePrefab) remainingBlue--;
    }

    private void PickNewRandomEnemyType()
    {
        List<GameObject> availableTypes = new List<GameObject>();
        if (remainingRed > 0) availableTypes.Add(redPrefab);
        if (remainingGreen > 0) availableTypes.Add(greenPrefab);
        if (remainingBlue > 0) availableTypes.Add(bluePrefab);

        if (availableTypes.Count == 0)
        {
            currentRandomEnemyType = null;
            return;
        }

        currentRandomEnemyType = availableTypes[Random.Range(0, availableTypes.Count)];
    }

    private void SpawnExtraSphere()
    {
        // Pick a random color
        int colorIndex = Random.Range(0, 3);
        GameObject prefabToSpawn = null;
        if (colorIndex == 0)
        {
            prefabToSpawn = redPrefab;
            remainingRed++;
        }
        else if (colorIndex == 1)
        {
            prefabToSpawn = greenPrefab;
            remainingGreen++;
        }
        else
        {
            prefabToSpawn = bluePrefab;
            remainingBlue++;
        }

        // Spawn at a random position within a range
        Vector3 randomPos = new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(-10f, 10f));
        Instantiate(prefabToSpawn, randomPos, Quaternion.identity);
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        waveName.text = "Game Over!";
        // Implement additional game over logic here
    }
}
