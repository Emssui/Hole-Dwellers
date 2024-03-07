using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet object
    public float spawnInterval = 2f; // Interval between bullet spawns

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning bullets
        StartCoroutine(SpawnBullets());
    }

    // Coroutine to spawn bullets at regular intervals
    IEnumerator SpawnBullets()
    {
        while (true)
        {
            // Spawn a bullet
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Wait for the specified interval before spawning the next bullet
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
