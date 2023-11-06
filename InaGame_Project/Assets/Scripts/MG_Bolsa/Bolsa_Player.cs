using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bolsa_Player : MonoBehaviour
{
    public bool controlsEnabled;

    private bool isJumping;
    private bool isAlive;
    private bool isDoubleJumping;
    public bool canDoubleJump;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Vector2 movement;


    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] private Rigidbody2D rig;
    //[SerializeField] private CapsuleCollider2D cap2d;
    //[SerializeField] private BoxCollider2D box2d;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        spriteR = GetComponentInChildren<SpriteRenderer>();
        rig = GetComponent<Rigidbody2D>();
        //cap2d = GetComponent<CapsuleCollider2D>();
        //box2d = GetComponent<BoxCollider2D>();

        //canDoubleJump = true;
    }


    private void FixedUpdate()
    {
        rig.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, rig.velocity.y);
    }

    void Update()
    {
        if (controlsEnabled)
        {
            Move();
            Jump();
        }
        else if (isAlive)
        {
            movement.x = 0;
            anim.SetInteger("transition", 0); //idle
        }
        else
        {
            movement.x = 0;
        }
    }

    private void Move()
    {
        movement.x = Input.GetAxis("Horizontal");


        if (movement.x > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);

        if (movement.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);


        if (movement == Vector2.zero && !isJumping)
        {
            anim.SetInteger("transition", 0); //idle
        }
        else if (!isJumping)
        {
            anim.SetInteger("transition", 1); //run
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping) // first jump
            {
                anim.SetInteger("transition", 2); //jump
                rig.velocity = new Vector2(rig.velocity.x, jumpForce);
                //rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
            }
            else if (isJumping && !isDoubleJumping && canDoubleJump) // second jump
            {
                rig.velocity = new Vector2(rig.velocity.x, jumpForce);
                isDoubleJumping = true;
            }
        }
    }

    public void PlayerDie()
    {
        isAlive = false;
        controlsEnabled = false;
        anim.SetInteger("transition", -1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
            isDoubleJumping = false;
        }
    }
}
