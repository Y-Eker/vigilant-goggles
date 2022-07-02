using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] Transform firePointPosition;
    [SerializeField] GameObject bullet;
    private bool shootPressed;

    // Start is called before the first frame update
    void Start()
    {
        shootPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
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
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firePointPosition.position, firePointPosition.rotation);
    }
}
