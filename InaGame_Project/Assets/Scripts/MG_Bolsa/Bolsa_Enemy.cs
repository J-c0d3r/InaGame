using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa_Enemy : MonoBehaviour
{

    [SerializeField] private float speed;

    private Rigidbody2D rig;
    private Transform player;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Bolsa_GameManager.instance.GameOver();
        }
    }

}
