using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variable declaration
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private float directionX = 0f;

    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle, run, jump, fall }

    [SerializeField] private AudioSource jumpSound;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    //jump functionality
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && OnGround())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            jumpSound.Play();
        }

        UpdateAnimationState();
    }

    // update the animation state depending on the amount of movement in each direction
    private void UpdateAnimationState()
    {
        MovementState state;
        if (directionX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }

        else if (directionX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }

        else
        {
            state = MovementState.idle; 
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    //detects if player is on ground
    private bool OnGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
