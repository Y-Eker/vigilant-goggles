using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D enemyCollider;
    [SerializeField] Rigidbody2D enemyBody;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        enemyCollider.enabled = false;
        enemyBody.gravityScale = 0f;
        this.enabled = false;
    }
}
