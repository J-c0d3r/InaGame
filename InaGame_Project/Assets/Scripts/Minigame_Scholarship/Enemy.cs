using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scholarship
{
    public class Enemy : MonoBehaviour
    {

        private float speed;

        private Transform player;

        void Start()
        {
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
                StartCoroutine(GameManager.instance.DiePlayer());
            }
        }

        public void SetSpeed(float spd)
        {
            speed = spd;
        }

    }
}
