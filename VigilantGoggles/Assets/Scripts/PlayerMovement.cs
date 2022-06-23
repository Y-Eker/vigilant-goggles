using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] float jumpForce = 4.5f;
    [SerializeField] float speed = 4.5f;
    private float horizontalInput = 0f;
    private bool canJump = true;
    private bool spacePressed = false;

    // Start is called before the first frame update
    void Start()
    {
        playerBody.position = new Vector2(-5.69f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            spacePressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (spacePressed && canJump)
        {
            playerBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            spacePressed = false;
        }
        playerBody.velocity = new Vector2(horizontalInput * speed, playerBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
