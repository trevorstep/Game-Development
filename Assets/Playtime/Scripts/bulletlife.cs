using UnityEngine;

public class bulletlife : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction*speed/100f;
    }
}
