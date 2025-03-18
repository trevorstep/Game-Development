using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 300f;
    private Rigidbody2D rb;
    private bool ignoreCollisions = false;
    private Vector2 movementDirection = Vector2.up; // Initialize to forward

    private Transform target = null;
    private bool wall = false;
    public float targetDistance = 10;
    private float targetRotationAngle = 0f; // Store the target rotation angle
    private bool isRotating = false; // Flag to check if the object is rotating
    public HealthBar health;

    public Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health.SetHealth(100);
    }

    void Update()
    {
        if (target != null)
        {
            Move();
        }
    }

    void FixedUpdate()
    {
        if (distance(player.position.x, player.position.y) < targetDistance)
        {
            target = player;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            wall = true;
        }
    }

    void Move()
    {
        if (!wall)
        {
            transform.position += transform.up * moveSpeed * -0.1f * Time.fixedDeltaTime;
        }
        else
        {
            float playery = player.transform.position.y;
            float playerx = player.transform.position.x;
            string direct = direction(playerx, playery, transform.position.x, transform.position.y);

            if (direct == "NE" || direct == "N")
            {
                targetRotationAngle = 90;
                rotate(90, 1);
            }
            if (direct == "NW" || direct == "W")
            {
                targetRotationAngle = 180;
                rotate(180, -1);
            }
            if (direct == "SE" || direct == "E")
            {
                targetRotationAngle = 0;
                rotate(0, 1);
            }
            if (direct == "SW" || direct == "S")
            {
                targetRotationAngle = 270;
                rotate(270, -1);
            }
        }
    }

    float distance(float x, float y)
    {
        return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
    }

    string direction(float targetx, float targety, float objx, float objy)
    {
        int NS = 0;
        int EW = 0;
        if (targetx > objx) { EW = 1; } else if (targetx < objx) { EW = -1; } else { EW = 0; }
        if (targety > objy) { NS = 1; } else if (targety < objy) { NS = -1; } else { NS = 0; }
        if (NS == 1)
        {
            if (EW == 1)
            {
                return "NE";
            }
            else if (EW == -1)
            {
                return "NW";
            }
            else
            {
                return "N";
            }
        }
        else if (NS == -1)
        {
            if (EW == 1)
            {
                return "SE";
            }
            else if (EW == -1)
            {
                return "SW";
            }
            else
            {
                return "S";
            }
        }
        return "";
    }

    void rotate(int targetAngle, int rotationDirection)
    {
        // Calculate the target rotation in degrees
        float currentAngle = transform.eulerAngles.z;
        float targetRotation = targetAngle;

        // If rotating counterclockwise, add 180 degrees (if needed)
        if (rotationDirection == -1)
        {
            targetRotation += 0f;
        }

        // Ensure the target angle is between 0 and 360
        if (targetRotation > 360f) targetRotation -= 360f;
        if (targetRotation < 0f) targetRotation += 360f;

        // Smoothly rotate towards the target rotation
        float angle = Mathf.MoveTowardsAngle(currentAngle, targetRotation, rotationSpeed * Time.deltaTime);

        // Apply the rotation to the object's transform
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Check if rotation is complete
        if (Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetRotation)) < 1f)
        {
            isRotating = false;
            wall = false; // Reset the wall flag after rotating
        }
        else
        {
            isRotating = true;
        }
    }
    void OnTriggerEnter2D(Collider2D obj){
        if (obj.gameObject.tag == "PlayerBullet"){
            health.IncrementHealth(15, true);
        }
    }
}
