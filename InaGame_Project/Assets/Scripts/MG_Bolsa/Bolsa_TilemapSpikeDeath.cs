using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa_TilemapSpikeDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Bolsa_GameManager.instance.RespawnByDeath();
        }
    }
}
