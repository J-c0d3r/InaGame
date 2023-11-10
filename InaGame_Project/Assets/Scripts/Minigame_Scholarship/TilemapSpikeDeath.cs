using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scholarship
{
    public class TilemapSpikeDeath : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.RespawnByDeath();
            }
        }
    }
}
