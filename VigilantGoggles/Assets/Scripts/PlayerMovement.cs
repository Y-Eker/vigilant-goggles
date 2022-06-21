using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] float jumpForce = 50f;
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
    }

    private void FixedUpdate()
    {
        if (spacePressed && canJump)
        {
            playerBody.AddForce(transform.up * jumpForce);
            spacePressed = false;
        }
    }
}
