using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D banditBody;
    [SerializeField] Transform banditTransform;
    [SerializeField] Animator animator;
    private float speed = 4.5f;
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        banditBody.position = new Vector2(-0.85f, -0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            banditTransform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (horizontalInput < 0)
        {
            banditTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        animator.SetBool("IsRunning", horizontalInput != 0);
    }

    private void FixedUpdate()
    {
        banditBody.velocity = new Vector2(horizontalInput * speed, banditBody.velocity.y);
    }
}
