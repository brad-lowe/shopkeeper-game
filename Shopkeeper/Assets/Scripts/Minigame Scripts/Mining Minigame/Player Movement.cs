using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMovement : Minigame
{

    public float speed = 5.0f;
    public float jumpGravityScale = 1f;
    public float fallGravityScale = 4;
    float allocatedButtonTime = 0.3f;
    float timeJumped = 0f;

    //bool canBeDestroyed = false;

    public Rigidbody2D rb;

    public float timerTillDestruction = 1f;

    bool inAJump = false;
    bool horizontalMovement = false;
    bool facingRight = true;


    bool isGameFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //blocks = GameObject.FindGameObjectsWithTag("Block");
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        //inAJump = false;0
        if(collider.gameObject.tag == "Block" && Input.GetKey(KeyCode.M))
        {
            timerTillDestruction -= Time.deltaTime;
            if (timerTillDestruction <= 0.0f)
            {
                Destroy(collider.gameObject);
                timerTillDestruction = 1f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameFinished)
        {
            EndMinigame();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inAJump = true;
        }
        if (inAJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            timeJumped += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) | timeJumped > allocatedButtonTime)
        {
            inAJump = false;
            timeJumped = 0f;
        }
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = jumpGravityScale;
        }
        else if(rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravityScale;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            facingRight = false;
            horizontalMovement = true; 
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            facingRight = true;
            horizontalMovement = true;
        }
        if (horizontalMovement)
        {
            if (facingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-1f * speed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) && !facingRight || (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) && facingRight)
        {
            horizontalMovement = false;
        }
        //float vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        //float horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        //transform.Translate(horizontal, rb.velocity.y, 0);
    }
}
