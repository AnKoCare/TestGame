using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float speed;
    private bool isfacingRight = true;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;
    [SerializeField] private float jumpForce = 500;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private bool isJumping = false;
    [SerializeField] public bool isMonster = false;
    [SerializeField] private Animator animator;
    private float left_right;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        groundLayer = (1 << LayerMask.NameToLayer("Ground"));
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = CheckGrounded();
        if (!isGrounded && rb.velocity.y < 0)
        {
            animator.SetTrigger("fall");
            isJumping = false;
        }
        if(isGrounded)
        {
            if(isJumping)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
                return;
            }

        }

        left_right = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(left_right * speed, rb.velocity.y);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);

        ChangeDirection();

        anim.SetFloat("move", Mathf.Abs(left_right));
    }

    private void ChangeDirection()
    {
        if(isfacingRight && left_right < 0 || !isfacingRight && left_right > 0)
        {
            isfacingRight = !isfacingRight;
            Vector3 size = transform.localScale;
            size.x = size.x * -1;
            transform.localScale = size;
        }
    }

    public void Jump()
    {
        if(isGrounded == false)
        {
            return;
        }
        isGrounded = false;
        isJumping = true;
        Debug.Log("jump");
        animator.SetTrigger("jump");
        rb.AddForce(jumpForce * Vector2.up);
    }

    private bool CheckGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red );
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);
        isJumping = false;
        return hit.collider != null;
    }
}
