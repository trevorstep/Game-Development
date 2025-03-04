using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 300f;
    private bool isRotating = false;
    private bool isMoving = true;
    private Rigidbody2D rb;
    private bool ignoreCollisions = false;
    private Vector2 movementDirection = Vector2.up; // Initialize to forward

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isMoving)
        {
            Move();
        }
        if (isRotating)
        {
            RotateTowardsMovementDirection();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!ignoreCollisions && collision.collider.CompareTag("Wall"))
        {
            ChooseRightDirection();
            StartCoroutine(IgnoreCollisionsForTime(0.1f));
        }
    }

    IEnumerator IgnoreCollisionsForTime(float time)
    {
        ignoreCollisions = true;
        yield return new WaitForSeconds(time);
        ignoreCollisions = false;
    }

    void RotateTowardsMovementDirection()
    {
        if (movementDirection != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg + 90;
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle)) < 1f)
            {
                isMoving = true;
                isRotating = false;
            }
            else
            {
                isRotating = true;
                isMoving = false;
            }
        }
    }

    void Move()
    {
        transform.position += transform.up * moveSpeed * Time.fixedDeltaTime;
    }

    void ChooseRightDirection()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Assuming your player has the "Player" tag

        if (player != null)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 enemyPosition = transform.position;
            Vector2 directionToPlayer = playerPosition - enemyPosition;

            // Calculate the relative forward vector of the enemy
            Vector2 enemyForward = transform.up;

            // Calculate the cross product to determine left or right
            float crossProduct = Vector3.Cross(enemyForward, directionToPlayer).z;

            if (crossProduct > 0) // Player is to the left
            {
                movementDirection = -transform.right; // Move left
            }
            else // Player is to the right or directly behind
            {
                movementDirection = transform.right; // Move right
            }
        }
    }
}