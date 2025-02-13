using UnityEngine;

public class TankInfo
{
    public int maxHealth = 100;
    public int playerHealth = 100;

    void Update()
    {
        //Ensures player health does not exceed the starting health
        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }

    }


}
