
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretAI : MonoBehaviour
{
    public float rotationSpeed = 300f;            // Speed at which the enemy rotates towards the target
    public float firingRange = 10f;               // Range at which the enemy will fire
    public Transform player;                      // Reference to the player (target)
    public GameObject projectilePrefab;           // The projectile to fire
    public Transform firePoint;                   // Point where the projectile will be fired

    private bool isFiring = false;                // Flag to determine if the enemy is firing

    void Update()
    {
        // Rotate towards the player
        RotateTowardsPlayer();

        // Fire the projectile when within range
        if (Vector2.Distance(transform.position, player.position) <= firingRange)
        {
            if (!isFiring) // Prevent continuous firing if already firing
            {
                FireProjectile();
            }
        }
    }

    void RotateTowardsPlayer()
    {
        // Get the direction from the enemy to the player
        Vector2 directionToPlayer = player.position - transform.position;

        // Calculate the angle to rotate towards
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg +90;

        // Smoothly rotate the object towards the player
        float step = rotationSpeed * Time.deltaTime;
        float newAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, angle, step);

        // Apply the rotation
        transform.rotation = Quaternion.Euler(0f, 0f, newAngle);
    }

    void FireProjectile()
    {
        // Instantiate the projectile at the firing point
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Prevent multiple projectiles being fired instantly
        isFiring = true;

        // Set a delay before firing again
        StartCoroutine(FireCooldown());
    }

    IEnumerator FireCooldown()
    {
        // Wait for a short period before allowing another shot
        yield return new WaitForSeconds(3f); // Adjust the cooldown time as needed
        isFiring = false;
    }
}