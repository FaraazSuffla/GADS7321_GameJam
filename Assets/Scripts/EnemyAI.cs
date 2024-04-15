using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float attackRange = 2f; // Range at which the enemy can attack the player
    public float attackDamage = 10f; // Amount of damage inflicted by the enemy's attack
    public float attackCooldown = 1f; // Cooldown between attacks
    public Animator animator; // Reference to the enemy's Animator component

    private Transform player; // Reference to the player's transform
    private bool canAttack = true; // Flag to control attack cooldown

    void Start()
    {
        // Find and store a reference to the player's transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if the player is within attack range and the enemy can attack
        if (Vector3.Distance(transform.position, player.position) <= attackRange && canAttack)
        {
            // Attack the player
            animator.SetTrigger("Attack"); // Trigger the attack animation
            Attack();
        }
    }

    // Method for enemy's attack
    void Attack()
    {
        // Reduce the player's health
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);

        // Set canAttack to false to start the attack cooldown
        canAttack = false;

        // Start a coroutine to reset canAttack after the attack cooldown
        StartCoroutine(ResetAttackCooldown());
    }

    // Coroutine to reset the attack cooldown
    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
