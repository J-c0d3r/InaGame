using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa_Portal : MonoBehaviour
{

    [SerializeField] private float timeDocToVisible;

    [SerializeField] private GameObject goldenDoc;
    private Animator anim;

    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        goldenDoc.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("canOpen", true);
            StartCoroutine(TurnVisibleDoc());
        }
    }

    IEnumerator TurnVisibleDoc()
    {
        yield return new WaitForSeconds(timeDocToVisible);
        goldenDoc.SetActive(true);
    }

}
