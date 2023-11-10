using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scholarship
{
    public class Document : MonoBehaviour
    {

        [SerializeField] private bool normalDocument;

        public AudioClip audioCollect;

        private void Start()
        {

        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {

                if (normalDocument)
                {
                    GameManager.instance.AddQtyCurrentDoc();
                }
                else
                {
                    GameManager.instance.AddQtyCurrentGoldenDoc();
                }

                AudioManager.audioManager.PlayOneShot(audioCollect, 1);

                Destroy(gameObject);
            }
        }

    }
}
