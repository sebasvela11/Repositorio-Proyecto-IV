using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    private float horizontalMove = 0;
    private float verticalMove = 0;
    public Joystick joystick;

    public float runSpeedHorizontal = 2;

    public float runSpeed = 1.25f;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 3;
    private bool canDoubleJump;

    Rigidbody2D rb2d;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1;

    public SpriteRenderer spriteRenderer;
    Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (horizontalMove > 0)
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (horizontalMove < 0)
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = true;
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (CheckGround.IsGrounded == false)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
            if (Mathf.Round(rb2d.velocity.x) != 0)
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }
        }

        if (rb2d.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }

    }

    private void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;

        //if (betterJump)
        //{
        //    if (rb2d.velocity.y < 0)
        //    {
        //        rb2d.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        //    }

        //    if (rb2d.velocity.y > 0 && !Input.GetKey("space"))
        //    {
        //        rb2d.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        //    }
        //}
    }

    public void Jump()
    {
        //if (Input.GetKey("space"))
        //{
        if (CheckGround.IsGrounded)
        {
            //PUEDE DAR UN SALTO DOBLE
            canDoubleJump = true;
            //REALIZA EL SALTO NORMAL
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                if (canDoubleJump)
                {
                    //ANIMACION SALTO DOBLE
                    animator.SetBool("DoubleJump", true);
                    //REALIZA EL DOBLE SALTO
                    rb2d.velocity = new Vector2(rb2d.velocity.x, doubleJumpSpeed);
                    //NO PUEDE DAR DOBLE SALTO
                    canDoubleJump = false;
                }
            }
        }
        //}
    }

}