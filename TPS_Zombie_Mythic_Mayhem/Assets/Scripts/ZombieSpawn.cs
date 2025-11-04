using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [Header("Zombie Spawn Variables")]
    public GameObject zombiePrefab;
    public Transform zombieSpawnPosition;
    public GameObject dangerZone1;
    private float repeatCycle = 1f;

    private List<GameObject> spawnedZombies = new List<GameObject>();


    private void Start()
    {
        // Pre-instantiate the zombie(s) in a disabled state
        GameObject zombie = Instantiate(zombiePrefab, zombieSpawnPosition.position, zombieSpawnPosition.rotation);
        //zombie.SetActive(false);
        spawnedZombies.Add(zombie);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Enable all pre-spawned zombies
            foreach (var zombie in spawnedZombies)
            {
                zombie.SetActive(true);
            }
            InvokeRepeating("EnemySpawner", 1f, repeatCycle);
            StartCoroutine(dangerZoneTimer());
            Destroy(gameObject, 10f);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    // If you want to spawn more zombies after trigger, use this method
    void EnemySpawner()
    {
        GameObject zombie = Instantiate(zombiePrefab, zombieSpawnPosition.position, zombieSpawnPosition.rotation);
        zombie.SetActive(true);
        spawnedZombies.Add(zombie);
    }


    IEnumerator dangerZoneTimer()
    {
        dangerZone1.SetActive(true);
        yield return new WaitForSeconds(5f);
        dangerZone1.SetActive(false);
    }
}
