using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scholarship
{
    public class Spawn : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                GameManager.instance.SpawnsController(gameObject.name);
                gameObject.SetActive(false);
            }
        }
    }
}
