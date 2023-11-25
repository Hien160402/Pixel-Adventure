using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D coll;
    private float dirX;
    private int jumpCount = 0;
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpforce = 7f;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle, running, jumping, falling, doublejump}
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");//chi tra ve 3 gia tri -1 or 0 or  1 (GetAxis tra ve -1 -> 1 ko bam tra ve 0)
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                jumpCount = 1;
                AudioManager.instance.PlaySFX("jump");
                rb.velocity = new Vector3(rb.velocity.x, jumpforce);
            }
            else if (jumpCount < 2)
            {
                jumpCount = 2;
                AudioManager.instance.PlaySFX("jump");
                rb.velocity = new Vector3(rb.velocity.x, jumpforce);
            }
        }
        if (IsGrounded())
        {
            jumpCount = 0;
        }
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
            if (jumpCount == 2)
            {
                state = MovementState.doublejump;
            }
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
