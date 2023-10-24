using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bolsa_GameManager : MonoBehaviour
{
    public static Bolsa_GameManager instance;

    [SerializeField] private int qtyTotalDoc;
    [SerializeField] private int qtyTotalGoldenDoc;
    private int qtyCurrentDoc;
    private int qtyCurrentGoldenDoc;

    [SerializeField] private GameObject inicialScreen;
    //[SerializeField] private GameObject gameOverScreen;
    //[SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI qtyDoc_txt;
    [SerializeField] private TextMeshProUGUI qtyGoldenDoc_txt;

    
    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        inicialScreen.SetActive(true);
        //gameOverScreen.SetActive(false);
        //winScreen.SetActive(false);

        qtyCurrentDoc = 0;
        qtyCurrentGoldenDoc = 0;
    }

    public void StartGame()
    {
        inicialScreen.SetActive(false);
    }




    
    public void AddQtyCurrentDoc()
    {
        qtyCurrentDoc++;
        qtyDoc_txt.text = qtyCurrentDoc.ToString() + " / 20";
    }

    public void AddQtyCurrentGoldenDoc()
    {
        qtyCurrentGoldenDoc++;
        qtyGoldenDoc_txt.text = qtyCurrentGoldenDoc.ToString() + " / 10";
    }

}
