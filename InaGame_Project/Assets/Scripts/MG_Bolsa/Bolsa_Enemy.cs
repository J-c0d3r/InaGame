using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa_Enemy : MonoBehaviour
{

    [SerializeField] private float speed;

    private Rigidbody2D rig;
    private Transform player;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (player.position.x >= transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            speed = 0;
            StartCoroutine(Bolsa_GameManager.instance.DiePlayer());
        }
    }

    public void SetSpeed(float spd)
    {
        speed = spd;
    }

}
