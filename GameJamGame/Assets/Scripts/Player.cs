 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed = 1;
    public float JumpHeight = 1;
    public float gravity = 1;
    public float deadZoneLimit = -7;
    public AudioClip Jump;
    public AudioClip Landing;
    public AudioClip Die;
    public AudioClip Foot;
    public AudioSource MusicSource;
    public AudioSource MusicSource2;

    private Rigidbody2D myRigidbody;
    private bool facingRight;
    private Animator myAnimator;
    private bool jump = false;

    bool grounded = false;
    public Transform groundCheck;
    private float groundRadius = 1f;
    public LayerMask whatIsGround;
    bool justLanded = false;
    float horizontal = 0;

    public GameController game;

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
            MusicSource.clip = Jump;
            MusicSource.Play();
            game.restartGame();
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        HandleJump();
        Flip(horizontal);

        RestValues();
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        /*if (grounded != justLanded)
        {
            MusicSource2.clip = Landing;
            MusicSource2.Play();
            grounded = justLanded;
        }*/
        
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            MusicSource.clip = Jump;
            MusicSource.Play();
        }

        if (grounded)
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && !MusicSource.isPlaying)
            {
                MusicSource.clip = Foot;
                MusicSource.Play();
                justLanded = false;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MusicSource.clip = Foot;
                MusicSource.Play();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MusicSource.clip = Foot;
                MusicSource.Play();
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                {
                    MusicSource.Stop();
                }
            }
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
        Debug.Log(this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"));
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
