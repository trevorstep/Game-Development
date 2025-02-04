using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour
{
    public GameObject projectile;
    public float speed;
    void Update() 
    {
        Vector3 direction=new Vector3(0,0,0);
        GameObject bullet=null;
        if(Input.GetKeyDown("mouse 0"))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePosition - transform.position;
            bullet = Instantiate(projectile, transform.position, Quaternion.identity, transform);            
        }
        if(bullet!=null){
            bullet.transform.position += speed*(direction)/100f;
        }
    }
}