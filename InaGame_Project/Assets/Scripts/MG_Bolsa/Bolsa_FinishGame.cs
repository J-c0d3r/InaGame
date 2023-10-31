using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa_FinishGame : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Bolsa_GameManager.instance.VictoryGame();
        }
    }

}
