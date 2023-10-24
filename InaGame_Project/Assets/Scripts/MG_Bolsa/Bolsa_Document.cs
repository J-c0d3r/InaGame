using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa_Document : MonoBehaviour
{

    [SerializeField] private bool normalDocument;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (normalDocument)
            {
                Bolsa_GameManager.instance.AddQtyCurrentDoc();
            }
            else
            {
                Bolsa_GameManager.instance.AddQtyCurrentGoldenDoc();
            }

            Destroy(gameObject);
        }
    }

}
