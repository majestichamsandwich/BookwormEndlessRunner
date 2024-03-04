using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D playerRB;
    public float jumpForce;

    [SerializeField] private Transform feetPosition;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpTime = 0.25f;


    private bool isGrounded = true;
    private bool isJumping = false;
    private float jumpTimer;

    // Update is called once per frame
    private void Update()
    {

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
    }
}
  