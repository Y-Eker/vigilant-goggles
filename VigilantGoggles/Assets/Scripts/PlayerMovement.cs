using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] Transform playerTransform;
    [SerializeField] float jumpForce = 7.5f;
    [SerializeField] float speed = 4.5f;
    public bool canJump = false;
    private float horizontalInput = 0f;
    private bool spacePressed = false;

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
}
