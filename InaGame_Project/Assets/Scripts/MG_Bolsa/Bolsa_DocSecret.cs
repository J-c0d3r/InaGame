using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bolsa_DocSecret : MonoBehaviour
{

    private TilemapRenderer tilemapRen;

    void Start()
    {
        tilemapRen = GetComponent<TilemapRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tilemapRen.sortingOrder = -1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tilemapRen.sortingOrder = 0;
    }
}
