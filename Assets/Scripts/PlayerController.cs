using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Movement Variables
    public float maxSpeed = 1f;
    private Vector2 moveDirection;
    public float jumpForce = 3f;
    private bool isJumping = false;

    // Components
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public bool hasKey = false; // Tracks if the player has picked up the key


    // Ground Detection
    private bool grounded = false;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private float groundCheckRadius = 0.2f;

    // Jumping


    // Player Input
    private PlayerInput _playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        _playerInput = GetComponent<PlayerInput>();
    }

    public void OnMove(InputValue moveValue)
    {
        moveDirection = moveValue.Get<Vector2>().normalized;
        anim.SetFloat("moveVelocity", Mathf.Abs(moveDirection.x)); // Update walk animation
    }

    public void OnJump(InputValue jumpValue)
    {
        if (jumpValue.isPressed && grounded) // Only jump if grounded
        {
            isJumping = true;
        }
    }

    private void Update()
    {
        // Move player
        rb.linearVelocity = new Vector2(moveDirection.x * maxSpeed, rb.linearVelocity.y);

        // Flip player sprite when changing direction
        if (moveDirection.x > 0)
            sprite.flipX = false;
        else if (moveDirection.x < 0)
            sprite.flipX = true;

        // Ground Check
        bool wasGrounded = grounded;
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        anim.SetBool("Grounded", grounded);

        if (!wasGrounded && grounded)
        {
            anim.SetTrigger("Land"); // Play landing animation
        }

        // Jumping Logic
        if (isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetTrigger("Jump");
            isJumping = false;
        }
    }


    private void OnEnable()
    {
        _playerInput?.ActivateInput();
    }

    private void OnDisable()
    {
        _playerInput?.DeactivateInput();
    }
}
