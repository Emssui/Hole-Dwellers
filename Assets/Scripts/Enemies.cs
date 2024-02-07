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
    public bool flip;
    void Start()
    {
        currentHealth = maxHealth;
        anim.SetBool("isMoving", true);
    }

    private void Update() {
        Vector3 scale = transform.localScale;

        if(player == null) {
            Debug.Log("Player Destroyed");
        } else {
            if(player.transform.position.x > transform.position.x) {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            } else {
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            }
        }

        transform.localScale = scale;
    }
 
    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if(currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("Enemy Die!!");

        if(gameObject.CompareTag("Enemies")) {
            Destroy(gameObject);
            Instantiate(Blood, transform.position, Quaternion.identity);
        }
    }
}
