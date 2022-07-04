using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    private int health = 100;
    private int bulletDamage = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health -= bulletDamage;
        }
    }
}
