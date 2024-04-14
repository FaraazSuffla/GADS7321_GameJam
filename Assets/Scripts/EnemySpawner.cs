using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int maxEnemies = 10;
    public GameObject player; // Public reference to the player GameObject

    private int currentEnemies = 0;
    private float timer = 0f;

    void Update()
    {
        if (currentEnemies < maxEnemies)
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnEnemy();
                timer = 0f;
            }
        }

        // Update enemy destinations
        UpdateEnemyDestinations();
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        if (agent != null && player != null)
        {
            // Set the destination of the NavMeshAgent to the player's position
            agent.SetDestination(player.transform.position);
        }
        currentEnemies++;
    }

    void UpdateEnemyDestinations()
    {
        // Update destinations for existing enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
            if (agent != null && player != null)
            {
                // Set the destination of the NavMeshAgent to the player's position
                agent.SetDestination(player.transform.position);
            }
        }
    }

    // Call this method to decrease the count of current enemies
    public void EnemyDestroyed()
    {
        currentEnemies--;
    }
}
