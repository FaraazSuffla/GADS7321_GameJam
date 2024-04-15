using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the player
    private float currentHealth; // Current health of the player

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        // Check if the player's health has dropped to zero or below
        if (currentHealth <= 0)
        {
            Die(); // Call the Die function if the player's health drops to or below zero
        }
    }

    void Die()
    {
        // Implement any game over logic here
        Debug.Log("Player has died!"); // Example: Log a message to the console
    }
}
