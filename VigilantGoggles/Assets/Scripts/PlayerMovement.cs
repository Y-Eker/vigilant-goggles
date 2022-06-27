using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] Transform playerTransform;
    [SerializeField] BoxCollider2D headCollider;
    [SerializeField] Animator animator;
    [SerializeField] float jumpForce = 7.5f;
    [SerializeField] float speed = 4.5f;
    [SerializeField] float crouchSpeed = 1.5f;
    public bool canJump = false;
    public bool canStand = true;
    private bool canCrouch = false;
    private float horizontalInput = 0f;
    private bool spacePressed = false;
    private bool crouchPressed = false; 

    // Start is called before the first frame update
    void Start()
    {
        playerBody.position = new Vector2(-5.69f, 0f);
        playerTransform.localScale = new Vector3(3, 3, 1);
        animator.SetBool("IsRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && canJump)
        {
            spacePressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0)
        {
            playerTransform.localScale = new Vector3(-3, 3, 1);
            animator.SetBool("IsRunning", true);
        }
        else if (horizontalInput > 0)
        {
            playerTransform.localScale = new Vector3(3, 3, 1);
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        crouchPressed = Input.GetKey("left ctrl");
        if (canJump)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
        canCrouch = canJump;
        animator.SetBool("IsCrouching", !headCollider.enabled);
    }

    private void FixedUpdate()
    {
        if (!headCollider.enabled)
        {
            spacePressed = false;
        }
        if (spacePressed && canJump && headCollider.enabled)
        {
            playerBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            spacePressed = false;
        }

        if (crouchPressed && canCrouch)
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
