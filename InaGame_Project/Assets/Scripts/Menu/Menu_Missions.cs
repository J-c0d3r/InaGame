using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Missions : MonoBehaviour
{

    [SerializeField] private GameObject achievPnl;

    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && achievPnl.activeSelf)
        {
            achievPnl.SetActive(false);
        }
    }

    public void ShowAchievements()
    {
        achievPnl.SetActive(true);
    }

    public void StartDocsRun()
    {
        SceneManager.LoadScene(2);
    }

}
