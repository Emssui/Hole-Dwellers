using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject Blood;
    public int maxHealth = 100;
    int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if(currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("Enemy Die!!");

        if(gameObject.CompareTag("Enemy1")) {
            Destroy(gameObject);
            Instantiate(Blood, transform.position, Quaternion.identity);
        }
    }
}
