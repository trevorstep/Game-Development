using UnityEngine;
public class bulletlife : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public Vector3 direction;
    float angle =0;
    private Rigidbody2D rb;

    void Start (){
        float z_x = direction.z/direction.x;
        Debug.Log(z_x);
        angle=Mathf.Atan(z_x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        rb = transform.GetComponent<Rigidbody2D>();



// Define the desired direction (e.g., forward)

 
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 forwardDirection = transform.forward;

        // Apply force in the forward direction

        rb.AddForce(forwardDirection * speed, ForceMode2D.Impulse);
    }
}
