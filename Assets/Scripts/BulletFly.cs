using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet

    // Update is called once per frame
    void Update()
    {
        // Move the bullet in the opposite direction of the enemy's facing
        MoveBullet();
    }

    void MoveBullet()
    {
        // Get the opposite direction of the enemy's facing
        Vector3 direction = -transform.right;

        // Move the bullet in that direction
        transform.position += direction * speed * Time.deltaTime;
    }
}
