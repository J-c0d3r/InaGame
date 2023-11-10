using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scholarship
{
    public class Sign : MonoBehaviour
    {

        private float timeCounter;
        [SerializeField] private float totalTimeToShowDoc;

        [SerializeField] private GameObject goldenDoc;

        private void Start()
        {
            goldenDoc.SetActive(false);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= totalTimeToShowDoc)
            {
                goldenDoc.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            timeCounter = 0f;
        }
    }
}
