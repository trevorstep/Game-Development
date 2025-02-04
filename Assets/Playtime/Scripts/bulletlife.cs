using UnityEngine;
public class bulletlife : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public Vector3 direction;
    float angle =0;

    void Start (){
        float z_x = direction.z/direction.x;
        Debug.Log(z_x);
        angle=Mathf.Atan(z_x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f,0f,speed/100f);
    }
}
