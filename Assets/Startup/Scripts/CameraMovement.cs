using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    void Update(){
        transform.position = player.transform.position + new Vector3(0,0,-1);
    }
}
