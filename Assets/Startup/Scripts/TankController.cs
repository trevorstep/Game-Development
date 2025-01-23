using UnityEngine;
using System.Collections;
public class TankController : MonoBehaviour 
{
    void start(){
        Vector3.position = new Vector3(-2,-1,0); //this should be changed later to take the vector3 of an empty spawn point
    }
    void Update(){
        if(Input.GetKeyDown("Left")){
            //start rotating the tank towards the West
        }

        if(Input.GetKeyDown("Right")){
            //start rotating the tank towards the East
        }

        if(Input.GetKeyDown("Up")){
            //start rotating the tank towards the North
        }

        if(Input.GetKeyDown("Down")){
            //start rotating the tank towards the South
        }

        if(Input.GetKeyDown("G")){
            //use G key to go forward
        }
    }
}
