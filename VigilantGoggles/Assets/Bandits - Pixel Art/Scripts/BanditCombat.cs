using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.4f;
    [SerializeField] LayerMask enemyLayers;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
