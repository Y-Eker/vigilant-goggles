using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovementScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletRigidbody;
    [SerializeField] float bulletSpeed = 12f;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
