using UnityEngine;

public class TurretPointer : MonoBehaviour
{
    void Update()
    {
        // Get the position of the mouse in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the sprite to the mouse
        Vector3 direction = mousePosition - transform.position;

        // Set the z-component to 0 to avoid depth issues
        direction.z = 0;

        // Calculate the angle to rotate the sprite
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg-90;

        // Apply the rotation to the sprite
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
