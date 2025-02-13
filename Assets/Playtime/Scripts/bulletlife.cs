using UnityEngine;

public class bulletlife : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed*-1; // Moves the object in the up direction (relative to its rotation)
        Destroy(gameObject, 3f);    
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Debug.Log("Player");
        }
        if(other.tag == "Wall"){
            Debug.Log("Wall");
            Destroy(gameObject);
        }
    }

}