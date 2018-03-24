 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed = 1;
    public float JumpHeight = 1;
    public float gravity = 1;
    public float deadZoneLimit = -7;

    private Rigidbody2D myRigidbody;
    private bool facingRight;
    private Animator myAnimator;
    private bool jump = false;

    bool grounded = false;
    public Transform groundCheck;
    private float groundRadius = 1f;
    public LayerMask whatIsGround;


    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myRigidbody.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        myAnimator.SetBool("Ground", grounded);

        HandleInput();

        if (myRigidbody.position.y < deadZoneLimit)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        HandleJump();
        Flip(horizontal);

        RestValues();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void HandleMovement(float horizontal)
    {
        myRigidbody.AddForce(Vector3.down * gravity * myRigidbody.mass);

        myRigidbody.velocity = new Vector2(horizontal * Speed, myRigidbody.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void HandleJump()
    {
        if (jump && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Jump") && grounded)
        {
            myAnimator.SetTrigger("jump");
            myRigidbody.velocity = new Vector3(0, 10 * JumpHeight * Time.deltaTime, 0);
        }

    }

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && !facingRight || horizontal > 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void RestValues()
    {
        jump = false;
    }
}
