using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public float avoidanceDistance = 1f;
    public LayerMask obstacleLayer;
    
    private Transform player;
    private Rigidbody2D rb;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null)
            return;

        Vector2 direction = (player.position - transform.position).normalized;
        Vector2 newDirection = AvoidObstacles(direction);
        rb.linearVelocity = direction * moveSpeed;
    }

    Vector2 AvoidObstacles(Vector2 targetDirection)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, detectionRange, obstacleLayer);
        
        if (hit.collider != null)
        {
            Vector2 perpendicular = Vector2.Perpendicular(hit.normal);
            Vector2 alternateDirection = Vector2.Dot(perpendicular, targetDirection) > 0 ? perpendicular : -perpendicular;
            return alternateDirection;
        }
        
        return targetDirection;
    }

    void OnDrawGizmos()
    {
        if (player != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)(AvoidObstacles((player.position - transform.position).normalized) * detectionRange));
        }
    }
}
