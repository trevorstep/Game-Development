using UnityEngine;

public class TankController : MonoBehaviour 
{
    void start(){
        GetComponent<Rigidbody2D>().position = new Vector3(-2, 2,0);
    }
    void Update(){

    }
}
