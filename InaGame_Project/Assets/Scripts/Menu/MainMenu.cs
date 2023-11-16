using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip audioBtn;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        audioSource.PlayOneShot(audioBtn);
        SceneManager.LoadScene(1);
    }

}
