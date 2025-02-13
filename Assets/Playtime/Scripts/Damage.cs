using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 10;
    private TankInfo player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
            player = collision.gameObject.GetComponent<TankInfo>();
            }

            player.TakeDamage(damage);
        }
    }
}