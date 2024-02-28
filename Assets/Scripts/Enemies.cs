using System.Collections;
using System.Collections.Generic;
using Pathfinding;
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
    public string playerName = "Player";
    public bool flip;

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
        // Check if the collider that entered the trigger is the player or any other target
        if (other.gameObject.name == playerName)
        {
        
            // Set the "Attack" trigger to play the attack animation
            animator.SetTrigger("attack");
        }
        else
        {
            Debug.Log("Player TAG does not exist");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // GetComponent<SpriteRenderer>().color = Color.red;
        // Invoke("ResetColor", 0.05f);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // void ResetColor(){
    //     GetComponent<SpriteRenderer>().color = Color.white;
    // }

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
