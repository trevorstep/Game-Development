using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour
{
    public GameObject projectile;
    public float speed;
    void Update() 
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction=mousePosition - transform.position;
        GameObject bullet=null;
        if(Input.GetMouseButtonDown(0))
        {
            bullet = Instantiate(projectile,transform.position,transform.rotation);   
        }
    }
}