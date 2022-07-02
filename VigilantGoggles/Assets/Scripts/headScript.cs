using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headScript : MonoBehaviour

{
    [SerializeField] PlayerMovement playerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Bullet")
        {
            playerMovementScript.canStand = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovementScript.canStand = true;
    }
}
