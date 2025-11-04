using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject redSpherePrefab;
    [SerializeField] private GameObject greenSpherePrefab;
    [SerializeField] private GameObject blueSpherePrefab;
    [SerializeField] private GameObject gameOverUI; // Assign in Inspector


    private int totalSpawnedRed = 0;
    private int totalSpawnedGreen = 0;
    private int totalSpawnedBlue = 0;

    private int totalDestroyed = 0;
    private int lastBatchDestroyed = 0;

    private Coroutine randomSpawnCoroutine;
    private bool gameOver = false;

    private void Start()
    {
        EnemyDestroyCounter.Instance.OnGameOver += HandleGameOver;
        SpawnInitialBatch();
        randomSpawnCoroutine = StartCoroutine(SpawnRandomSphereRoutine());
    }

    private void SpawnInitialBatch()
    {
        SpawnSpheres(15, 10, 5);
        totalSpawnedRed += 15;
        totalSpawnedGreen += 10;
        totalSpawnedBlue += 5;
    }

    private void SpawnSpheres(int red, int green, int blue)
    {
        for (int i = 0; i < red; i++)
            SpawnSphere(redSpherePrefab, "Red");
        for (int i = 0; i < green; i++)
            SpawnSphere(greenSpherePrefab, "Green");
        for (int i = 0; i < blue; i++)
            SpawnSphere(blueSpherePrefab, "Blue");
    }

    private void SpawnSphere(GameObject prefab, string colorTag)
    {
        if (gameOver) return;

        Vector3 position = new Vector3(
            Random.Range(-10f, 10f),
            1f,
            Random.Range(-10f, 10f)
        );
        GameObject sphere = Instantiate(prefab, position, Quaternion.identity, transform);

        Enemy enemy = sphere.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.OnDestroyed += OnSphereDestroyed;
        }

        // Track total spawned for ratio calculation
        if (colorTag == "Red") totalSpawnedRed++;
        else if (colorTag == "Green") totalSpawnedGreen++;
        else if (colorTag == "Blue") totalSpawnedBlue++;
    }

    private IEnumerator SpawnRandomSphereRoutine()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(5f);
            int color = Random.Range(0, 3);
            if (color == 0)
            {
                SpawnSphere(redSpherePrefab, "Red");
            }
            else if (color == 1)
            {
                SpawnSphere(greenSpherePrefab, "Green");
            }
            else
            {
                SpawnSphere(blueSpherePrefab, "Blue");
            }
        }
    }

    private void OnSphereDestroyed(GameObject sphere)
    {
        if (sphere.CompareTag("Red"))
            EnemyDestroyCounter.Instance.AddDestroyed("Red");
        else if (sphere.CompareTag("Green"))
            EnemyDestroyCounter.Instance.AddDestroyed("Green");
        else if (sphere.CompareTag("Blue"))
            EnemyDestroyCounter.Instance.AddDestroyed("Blue");

        totalDestroyed++;
        lastBatchDestroyed++;

        // Every 10 destroyed spheres, spawn a new batch of 10 spheres matching destroyed color ratio
        if (lastBatchDestroyed == 10)
        {
            lastBatchDestroyed = 0;
            SpawnBatchByDestroyedRatio();
        }
    }

    private void SpawnBatchByDestroyedRatio()
    {
        int red = EnemyDestroyCounter.Instance.DestroyedRed;
        int green = EnemyDestroyCounter.Instance.DestroyedGreen;
        int blue = EnemyDestroyCounter.Instance.DestroyedBlue;

        int total = red + green + blue;
        if (total == 0) return; // Avoid division by zero

        // Calculate ratio for 10 spheres
        float ratioRed = (float)red / total;
        float ratioGreen = (float)green / total;
        float ratioBlue = (float)blue / total;

        int batchRed = Mathf.RoundToInt(ratioRed * 10);
        int batchGreen = Mathf.RoundToInt(ratioGreen * 10);
        int batchBlue = 10 - batchRed - batchGreen; // Ensure total is 10

        // Correction for rounding errors
        if (batchRed < 0) batchRed = 0;
        if (batchGreen < 0) batchGreen = 0;
        if (batchBlue < 0) batchBlue = 0;

        SpawnSpheres(batchRed, batchGreen, batchBlue);
    }


    private void HandleGameOver()
    {
        gameOver = true;
        if (randomSpawnCoroutine != null)
            StopCoroutine(randomSpawnCoroutine);
        Debug.Log("Spawning stopped due to game over.");

        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }

}
