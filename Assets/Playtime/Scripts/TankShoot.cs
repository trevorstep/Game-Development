using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour
{
    void Update() 
    {

        if(Input.GetKeyDown("mouse 0"))
        {
            Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 direction = mousePosition - transform.position;

            
        }
    }
}