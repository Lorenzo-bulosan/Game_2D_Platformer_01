using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// controls for player: Dango
public class PlayerController : MonoBehaviour
{
    // game objects
    private Rigidbody2D _body;
    private string tagGround = "Ground";

    // animation parameters
    private Animator _animator;
    private string paramWalking = "walking";
    private string paramGrounded = "grounded";
    private string paramJump = "jump";
    private bool isWalking;
    private bool isGrounded;

    // inputs
    private bool isJumping;
    private float horizontalInput;

    // player variables
    [SerializeField]
    private float SpeedX = 7;
    private float SpeedY = 11;
    private float velocityX, velocityY;

    public bool CanAttack { get; set; } = true;

    private void Awake()
    {
        // set instances
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
        velocityX = horizontalInput * SpeedX;
        _body.velocity = new Vector2(velocityX, _body.velocity.y); // speed in all 2 directions
    }

    private void DetectJump() 
    {
        isJumping = Input.GetKey(KeyCode.Space);

        if (isJumping && isGrounded)
        {
            _body.velocity = new Vector2(_body.velocity.x, SpeedY);
            isGrounded = false;
            _animator.SetTrigger(paramJump);
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
        _animator.SetBool(paramWalking, isWalking);
        _animator.SetBool(paramGrounded, isGrounded);
    }

    // detects collisions between colidable bodies
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if collision object has tag ground that we gave to the ground game obj
        if(collision.gameObject.tag == tagGround)
        {
            isGrounded = true;
        }
    }
}
