using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa_AudioManager : MonoBehaviour
{
    public static Bolsa_AudioManager audioManager;

    [SerializeField] private AudioSource audioSourceSFX;
    [SerializeField] private AudioSource audioSourceSongs;

    private void Awake()
    {
        audioManager = this;
    }

    void Start()
    {
        //audioSourceSFX = GetComponent<AudioSource>();
        //audioSourceSongs = GetComponent<AudioSource>();
    }

    public void PlayOneShot(AudioClip clip, float volume)
    {
        audioSourceSFX.PlayOneShot(clip, volume);
    }

    public void PlaySong(AudioClip song, bool isLoop)
    {
        audioSourceSongs.clip = song;
        audioSourceSongs.Play();
        audioSourceSongs.loop = isLoop;
    }

}
