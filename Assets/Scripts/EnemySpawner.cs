using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign the enemy prefab in the Inspector
    public float spawnInterval = 2f; // Interval between spawns
    public int maxEnemies = 10; // Maximum number of enemies to spawn

    private int currentEnemies = 0;
    private float timer = 0f;

    void Update()
    {
        // Check if we can spawn a new enemy
        if (currentEnemies < maxEnemies)
        {
            timer += Time.deltaTime; // Increment timer
            if (timer >= spawnInterval)
            {
                SpawnEnemy(); // Spawn an enemy
                timer = 0f; // Reset timer
            }
        }
    }

    void SpawnEnemy()
    {
        // Instantiate the enemy prefab at the spawner's position and rotation
        Instantiate(enemyPrefab, transform.position, transform.rotation);
        currentEnemies++; // Increment the count of current enemies
    }

    // Call this method to decrease the count of current enemies
    public void EnemyDestroyed()
    {
        currentEnemies--;
    }
}
