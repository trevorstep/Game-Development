using UnityEngine;

public class bulletlife : MonoBehaviour
{
    private float speed = 100f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed; // Moves the object in the up direction (relative to its rotation)
        Destroy(gameObject, 3f); // Destroys the object after 3 seconds
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); // Destroys the object on collision
    }
}