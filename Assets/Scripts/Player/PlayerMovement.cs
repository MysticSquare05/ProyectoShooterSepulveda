using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 5f;
    public float jumpForce = 9f;
    public float jumpTimeCounter = 0f;
    public float jumpTime = 0.15f;
    public float coyoteTime = 0.1f;
    public float coyoteTimeCounter;
    public float jumpBufferTime = 0.2f;
    public float jumpBufferCounter;

    public float horizontalInput;

    [Header("Grounding")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    Rigidbody2D rb;
    Animator anim;
    AudioSource audio;

    public AudioClip jumpSFX;
    public AudioClip shootSFX;


    public bool isJumping = false;

    public int facingDirection = 1;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("horizontal", Mathf.Abs(horizontalInput));

        if (horizontalInput > .1f && facingDirection < 0 || horizontalInput < -.1f && facingDirection > 0)
        {
            Flip();
        }

        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
            anim.SetBool("isJumping", false);
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
            anim.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            audio.generator = jumpSFX;
            audio.Play();
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetButtonDown("Shoot"))
        {
            audio.generator = shootSFX;
            audio.Play();
            anim.SetBool("isShooting", true);
            
        } 
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        if (isJumping)
        {

            Jump();
        }
    }

    void Jump()
    {
        if (jumpTimeCounter > 0 && Input.GetButton("Jump"))
        {

            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
            jumpBufferCounter = 0f;
        }
        else
        {
            coyoteTimeCounter = 0f;
            isJumping = false;
        }

    }

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    void Flip()
    {
        facingDirection *= -1;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void StopShooting()
    { 
        anim.SetBool("isShooting", false);
    }
}
