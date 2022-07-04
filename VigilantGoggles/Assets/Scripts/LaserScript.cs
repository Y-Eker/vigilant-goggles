using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] Transform firePointPosition;
    [SerializeField] GameObject bullet;
    [SerializeField] float shootingDelay = 0.2f;
    private bool shootPressed;
    private float shotTime;

    // Start is called before the first frame update
    void Start()
    {
        shootPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > shotTime + shootingDelay)
        {
            shootPressed = true;
        }
    }

    private void FixedUpdate()
    {
        if (shootPressed)
        {
            Shoot();
            shootPressed = false;
            shotTime = Time.time;
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firePointPosition.position, firePointPosition.rotation);
    }
}
