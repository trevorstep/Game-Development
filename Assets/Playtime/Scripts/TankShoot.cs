using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour
{
    void Update() 
    {
        if(Input.GetKeyDown("mouse 0"))
        {
            //Test to see of function returns true when primary button on mouse is clicked
            Debug.Log("Mouse was clicked");
        }
    }
}