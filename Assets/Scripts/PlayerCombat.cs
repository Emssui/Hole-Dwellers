using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackRange;
    public float attackPoint = 0.5f;

    public Animator animator;
    public LayerMask enemyLayers;

    public int attackDamage = 20;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Attack();      
        }
    }

    void Attack() {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackRange.position, attackPoint, enemyLayers);

        foreach(Collider2D enemy in hitEnemies) {
           enemy.GetComponent<Enemies>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected() {
        if (attackRange == null)
        return;

        Gizmos.DrawWireSphere(attackRange.position, attackPoint);
    }
}
