using UnityEngine;

public class TankInfo : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }


}
