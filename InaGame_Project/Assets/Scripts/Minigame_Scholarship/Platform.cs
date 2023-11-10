using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scholarship
{
    public class Platform : MonoBehaviour
    {

        private Animator anim;

        void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                anim.SetTrigger("fall");
                Destroy(this, 2.5f);
            }
        }
    }
}

