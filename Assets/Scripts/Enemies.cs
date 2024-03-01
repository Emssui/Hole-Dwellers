using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public GameObject Blood;
    public GameObject player;
    public Animator anim;
    public Animator animator;
    public string playerName = "Player";
    public bool flip;

    // Knockback variables
    public float knockbackForce = 100f;
    public float knockbackDuration = 0.1f;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        animator = GetComponent<Animator>();
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
        // Check if the collider that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Set the "Attack" trigger to play the attack animation
            animator.SetTrigger("attack");

            // Apply knockback to the player
            StartCoroutine(Knockback(other.gameObject.GetComponent<Rigidbody>()));
        }
        else
        {
            Debug.Log("Player TAG does not exist");
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

    IEnumerator Knockback(Rigidbody playerRigidbody)
    {
        // Calculate knockback direction
        Vector3 knockbackDirection = (player.transform.position - transform.position).normalized;

        // Apply knockback force
        playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

        // Wait for knockback duration
        yield return new WaitForSeconds(knockbackDuration);

        // Reset velocity
        playerRigidbody.velocity = Vector3.zero;
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
