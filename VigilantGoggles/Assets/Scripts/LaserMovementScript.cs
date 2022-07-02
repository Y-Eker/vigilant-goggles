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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
