using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour
{
    void Update() 
    {
        if(Input.GetKeyDown("mouse 0"))
        {
            Debug.Log("Mouse was clicked");
        }
    }
}