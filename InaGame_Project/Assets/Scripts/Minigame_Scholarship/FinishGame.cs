using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scholarship
{
    public class FinishGame : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                GameManager.instance.VictoryGame();
            }
        }

    }
}

