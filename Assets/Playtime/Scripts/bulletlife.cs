using UnityEngine;

public class bulletlife : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody2D rb;
    public AudioSource fireSound;
    private string parentTag="";
    bulletlife(string ptag){
        parentTag=ptag;
    }
    void Start()
    {
        Instantiate(fireSound);
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed * -1;

        if (transform.parent != null)
        {
            parentTag = transform.parent.tag;
        }
        else
        {
            Debug.LogWarning("Bullet has no parent!");
        }
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == parentTag)
        {
            Debug.Log("Player");
        }

        if (other.tag != parentTag)
        {
            Destroy(gameObject);
        }
    }
}