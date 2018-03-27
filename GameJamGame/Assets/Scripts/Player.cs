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
    ParticleSystem Particle;
    private Rigidbody2D myRigidbody;
    private bool facingRight;
    private Animator myAnimator;
    private bool jump = false;

    bool grounded = false;
    public Transform groundCheck;
    private float groundRadius = 1f;
    public LayerMask whatIsGround;
    float horizontal = 0;

    private MovingTile mt;
    bool playerOnMovingTile = false;

    public GameController game;

    bool dead = false;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myRigidbody.freezeRotation = true;
        Particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        myAnimator.SetBool("Ground", grounded);

        HandleInput();

        if (myRigidbody.position.y < deadZoneLimit && !dead && !myRigidbody.isKinematic)
        {
            game.restartGame();
            dead = true;
            //Application.LoadLevel(Application.loadedLevel);
        }

        if (playerOnMovingTile && mt.horizontal)
        {
            if (mt.movingLeft)
            {
                transform.Translate(new Vector2(-0.0425f, 0));
            }
            else
            {
                transform.Translate(new Vector2(0.0425f, 0));
            }
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
        if (coll.gameObject.tag == "finishTag")
        {
            myRigidbody.isKinematic = true;
            game.updateLevel();
        }

        if (coll.gameObject.tag == "movingTileTag")
        {
            mt = coll.transform.GetComponent(typeof(MovingTile)) as MovingTile; // coll.transform.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            playerOnMovingTile = true;
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        /*if (coll.gameObject.tag == "movingTileTag")
        {*/
            playerOnMovingTile = false;
        //}
    }

    private void HandleInput()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space) && myRigidbody.position.y > deadZoneLimit)
        {
            jump = true;
            
            MusicSource.clip = Jump;
            MusicSource.Play();
        }

        if ((grounded && myRigidbody.position.y > deadZoneLimit) && !myRigidbody.isKinematic)
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && !MusicSource.isPlaying)
            {
                MusicSource.clip = Foot;
                MusicSource.Play();
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
        if (myRigidbody.isKinematic || myRigidbody.position.y < deadZoneLimit)
        {
            MusicSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    private void HandleMovement(float horizontal)
    {
        if ( horizontal == 0)
        {
           
        }
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
