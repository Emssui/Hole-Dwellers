using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Animations;

public class Enemies : MonoBehaviour
{
    public GameObject Blood;
    public int maxHealth = 100;
    int currentHealth;
    public GameObject player;
    public Animator anim;
    public Animator animator;
    public bool flip;
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        anim.SetBool("isMoving", true);
    }

    private void Update()
    {
        Vector3 scale = transform.localScale;

        if (player == null)
        {
            Debug.Log("Player Destroyed");
        }
        else
        {
            if (player.transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            }
        }

        transform.localScale = scale;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is the player or any other target
        if (other.CompareTag("Player"))
        {
            Debug.Log("ATATTA");
            // Set the "Attack" trigger to play the attack animation
            anim.SetTrigger("attack");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Die!!");

        if (gameObject.CompareTag("Enemies"))
        {
            Destroy(gameObject);
            Instantiate(Blood, transform.position, Quaternion.identity);
        }
    }
}
