using UnityEngine;

public class TankInfo : MonoBehaviour
{
    public int maxHealth = 100;
    public int playerHealth;

    void Start()
    {
        playerHealth = maxHealth;
    }
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }

    }


}
