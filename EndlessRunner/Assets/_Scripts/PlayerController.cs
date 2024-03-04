using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D playerRB;
    public float jumpForce;
    public Animator animator;

    [SerializeField] private Transform feetPosition;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpTime = 0.25f;
    [SerializeField] private float speed = 8f;



    private bool isGrounded = true;
    private bool isJumping = false;
    private float jumpTimer;
    private float horizontal;
    private bool isFacingRight = true;

    // Update is called once per frame
    private void Update()
    {

        if(Input.GetButton("Horizontal"))
        {
            animator.SetFloat("Moving", 0.01f);
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetFloat("Moving", 0f);
        }

        if (Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer) == true)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            playerRB.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            isJumping = true;
           
        }

        if (isJumping == true && Input.GetButton("Jump"))
        {
            if(jumpTimer < jumpTime)
            {
                playerRB.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
                Debug.Log(jumpTimer + jumpTime);
            }
            else
            {
                isJumping = false;
            }
        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();
    }
    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(horizontal * speed, playerRB.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
  