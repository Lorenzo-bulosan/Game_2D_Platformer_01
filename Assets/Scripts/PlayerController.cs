using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// controls for player movement
public class PlayerController : MonoBehaviour
{
    // game objects
    private Rigidbody2D body;

    private const string TAG_GROUND = "Ground";

    // animation parameters
    private Animator animator;
    private static readonly int Jump = Animator.StringToHash("jump");
    private static readonly int Walking = Animator.StringToHash("grounded");
    private static readonly int Grounded = Animator.StringToHash("walking");
    private bool isWalking;
    private bool isGrounded;
    
    // inputs
    private bool isJumping;
    private float horizontalInput;


    // player variables

    [SerializeField]
    private float speedX = 7;

    private const float SPEED_Y = 11;
    private float velocityX;

    public bool CanAttack { get; set; } = true;

    private void Awake()
    {
        // set instances
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // on every frame
    private void Update()
    {
        DetectHorizonalMovement();
        DetectJump();
        DetectFlip();
        EnableAnimations();
    }

    private void DetectHorizonalMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        velocityX = horizontalInput * speedX;
        body.velocity = new Vector2(velocityX, body.velocity.y); // speed in all 2 directions
    }

    private void DetectJump() 
    {
        isJumping = Input.GetKey(KeyCode.Space);

        if (isJumping && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, SPEED_Y);
            isGrounded = false;
            animator.SetTrigger(Jump);
        }
    }

    private void DetectFlip()
    {
        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector2(1,1);
        }
        else if(horizontalInput < -0.01)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    // sets the animations to these values as they change
    private void EnableAnimations()
    {
        isWalking = horizontalInput != 0;
        animator.SetBool(Walking, isWalking);
        animator.SetBool(Grounded, isGrounded);
    }

    // detects collisions between colidable bodies
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if collision object has tag ground that we gave to the ground game obj
        if(collision.gameObject.CompareTag(TAG_GROUND))
        {
            isGrounded = true;
        }
    }
}