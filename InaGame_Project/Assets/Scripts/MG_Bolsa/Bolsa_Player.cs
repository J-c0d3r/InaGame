using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bolsa_Player : MonoBehaviour
{

    private bool isJumping;
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
    }


    private void FixedUpdate()
    {
        rig.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, rig.velocity.y);
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        movement.x = Input.GetAxis("Horizontal");


        if (movement.x > 0)
            spriteR.flipX = false;

        if (movement.x < 0)
            spriteR.flipX = true;


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
            anim.SetInteger("transition", 2); //jump
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            //rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
        }
    }
}
