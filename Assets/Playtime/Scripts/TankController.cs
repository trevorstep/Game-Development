using UnityEngine;

public class TankController : MonoBehaviour
{
    public float rotationSpeed = 300f;
    public float moveSpeed = 5f;
    private Vector2 movementDirection;
    private bool isRotating = false;
    private bool isMoving = false;

    void Update()
    {
        GetInput();
        if (isMoving)
        {
            RotateTowardsMovementDirection();
        }
    }

    void FixedUpdate()
    {
        if (!isRotating && isMoving)
        {
            Move();
        }
    }

    void GetInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            movementDirection = new Vector2(horizontal, vertical).normalized;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void RotateTowardsMovementDirection()
    {
        if (movementDirection != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg+90;
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            
            if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle)) < 1f)
            {
                isRotating = false;
            }
            else
            {
                isRotating = true;
            }
        }
    }

    void Move()
    {
        transform.position += (Vector3)movementDirection * moveSpeed * Time.fixedDeltaTime;
    }
}
