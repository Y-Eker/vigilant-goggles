using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] Transform playerTransform;
    [SerializeField] BoxCollider2D headCollider;
    [SerializeField] float jumpForce = 7.5f;
    [SerializeField] float speed = 4.5f;
    [SerializeField] float crouchSpeed = 2.5f;
    public bool canJump = false;
    public bool canStand = true;
    private float horizontalInput = 0f;
    private bool spacePressed = false;
    private bool crouchPressed = false; 

    // Start is called before the first frame update
    void Start()
    {
        playerBody.position = new Vector2(-5.69f, 0f);
        playerTransform.localScale = new Vector3(3, 3, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            spacePressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0)
        {
            playerTransform.localScale = new Vector3(-3, 3, 1);
        }
        if (horizontalInput > 0)
        {
            playerTransform.localScale = new Vector3(3, 3, 1);
        }
        crouchPressed = Input.GetKey("left ctrl");   
    }

    private void FixedUpdate()
    {
        if (spacePressed && canJump)
        {
            playerBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            spacePressed = false;
        }

        if (crouchPressed)
        {
            headCollider.enabled = false;
            playerBody.velocity = new Vector2(horizontalInput * crouchSpeed, playerBody.velocity.y);
        }

        else
        {
            if (canStand)
            {
                headCollider.enabled = true;
                playerBody.velocity = new Vector2(horizontalInput * speed, playerBody.velocity.y);
            }

            else
            {
                headCollider.enabled = false;
                playerBody.velocity = new Vector2(horizontalInput * crouchSpeed, playerBody.velocity.y);
            }
        }
          
    }
}
