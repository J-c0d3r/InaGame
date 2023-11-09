using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerGeneral : MonoBehaviour
{
    public static GameManagerGeneral instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void UnlockAchievementAlotPaper()
    {

    }

    public void UnlockAchievementPendentDocumentation()
    {

    }

    public void UnlockAchievementSalesMasterFinatel()
    {

    }
}
