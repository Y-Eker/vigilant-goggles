using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.4f;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] int damage = 25;
    private bool canAttack = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
    }
    public void Attack()
    {
        if (canAttack)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            canAttack = false;
        }
        
    }

    public void canAttackSetter()
    {
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
