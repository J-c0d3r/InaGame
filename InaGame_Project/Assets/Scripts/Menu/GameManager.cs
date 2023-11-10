using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float xp_player;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    public void SetXPPlayer(float xp)
    {
        xp_player = PlayerPrefs.GetFloat("XP");
        xp_player += xp;
        PlayerPrefs.SetFloat("XP", xp_player);
    }

}
