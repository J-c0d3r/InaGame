using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Missions : MonoBehaviour
{

    [SerializeField] private GameObject achievPnl;
    [SerializeField] private TextMeshProUGUI xp_txt;

    [SerializeField] private GameObject check_img_DocsRace;
    [SerializeField] private Image achiev_DocsRace_1;
    [SerializeField] private Image achiev_DocsRace_2;
    [SerializeField] private Image achiev_DocsRace_3;

    public AudioSource audioSource;
    public AudioClip audio_Button;


    void Start()
    {
        achievPnl.SetActive(false);

        UpdateXPInterface();
        UpdateMissions();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && achievPnl.activeSelf)
        {
            achievPnl.SetActive(false);
        }
    }

    public void UpdateXPInterface()
    {
        xp_txt.text = ((int)PlayerPrefs.GetFloat("XP")).ToString();
    }

    private void UpdateMissions()
    {
        if (PlayerPrefs.GetInt("Corrida dos Documentos") == 1)
            check_img_DocsRace.SetActive(true);
        else
            check_img_DocsRace.SetActive(false);
    }

    public void ShowAchievements()
    {
        achievPnl.SetActive(true);

        UpdateAchievements();
    }

    private void UpdateAchievements()
    {
        if (PlayerPrefs.GetInt("Muita Papelada...") == 1)
            achiev_DocsRace_1.color = new Color(1, 1, 1, 1);

        if (PlayerPrefs.GetInt("Documentacao Pendente...") == 1)
            achiev_DocsRace_2.color = new Color(1, 1, 1, 1);

        if (PlayerPrefs.GetInt("Mestre dos Descontos FINATEL") == 1)
            achiev_DocsRace_3.color = new Color(1, 1, 1, 1);
    }

    public void StartDocsRun()
    {
        audioSource.PlayOneShot(audio_Button);
        SceneManager.LoadScene(2);
    }

}
