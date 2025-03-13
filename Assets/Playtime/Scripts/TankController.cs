using UnityEngine;

public class TankController : MonoBehaviour
{
    public float rotationSpeed = 300f;
    public float moveSpeed = 5f;
    public float speed = 1f; // this is needed for the tank tracks animation. sorry.
    private Vector2 movementDirection;
    private bool isRotating = false;
    private bool isMoving = false;
    public GameObject startup;
    public string spawnPointName = "SpawnPoint"; // Name of the spawn point
    public HealthBar health;

    void Start()
    {
        Spawn();
        health.SetMaxHealth(100);

    }

    void Spawn()
    {
        // Find the Startup object using its name

        if (startup == null)
        {
            Debug.LogError("Startup object not found!");
            return; // Exit early to prevent further errors
        }

        // Find the SpawnPoint using a recursive search
        Transform spawnPointTransform = FindChildRecursive(startup.transform, spawnPointName);

        if (spawnPointTransform == null)
        {
            Debug.LogError("SpawnPoint not found!");
            return; // Exit early
        }

        transform.position = spawnPointTransform.position;
    }

    // Recursive function to find a child by name
    Transform FindChildRecursive(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child;
            }

            Transform found = FindChildRecursive(child, name);
            if (found != null)
            {
                return found;
            }
        }
        return null; // Not found
    }


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
        if(health.GetHealth()<=0){
            Destroy(gameObject);
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
            // speed = moveSpeed;
        }
        else
        {
            isMoving = false;
            // speed = 0f;
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
    void OnTriggerEnter2D(Collider2D obj){
        if (obj.gameObject.tag == "EnemyBullet"){
            health.IncrementHealth(15, true);
        }
    }
}