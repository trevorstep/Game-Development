using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour
{
    public GameObject projectile;
    public float speed;
    public float reload_time = 1000f;
    float timer =1000f;
    
    void Update() 
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction=mousePosition - transform.position;
        GameObject bullet=null;
        if(Input.GetMouseButtonDown(0) && timer>reload_time)
        {
            bullet = Instantiate(projectile,transform.position,transform.rotation);   
            timer=0;
        }
        timer++;
        
    }
}