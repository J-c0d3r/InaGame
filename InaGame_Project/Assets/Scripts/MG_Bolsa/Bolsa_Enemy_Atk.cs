using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa_Enemy_Atk : MonoBehaviour
{

    private Animator anim;


    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("attack");                       
    }

}
