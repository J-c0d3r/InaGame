using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bolsa_GameManager : MonoBehaviour
{
    public static Bolsa_GameManager instance;

    [SerializeField] private float[] ArraySpeedEnemy;
    [SerializeField] private int qtyTotalDoc;
    [SerializeField] private int qtyTotalGoldenDoc;
    private int qtyCurrentDoc;
    private int qtyCurrentGoldenDoc;
    private int currentSpawnPoint;
    private int qtyLifePlayer;
    private int qtyTotalLifePlayer;
    private float seconds;
    private float xp;
    private int minutes;
    private bool gameRunning;

    [SerializeField] private GameObject inicialScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject finalScreen;
    [SerializeField] private TextMeshProUGUI qtyDoc_txt;
    [SerializeField] private TextMeshProUGUI qtyDocWinScreen_txt;
    [SerializeField] private TextMeshProUGUI qtyGoldenDoc_txt;
    [SerializeField] private TextMeshProUGUI qtyGoldenDocWinScreen_txt;
    [SerializeField] private GameObject finalMsgGood_txt;
    [SerializeField] private GameObject finalMsgBad_txt;
    [SerializeField] private TextMeshProUGUI percBolsa_txt;
    [SerializeField] private TextMeshProUGUI xp_txt;
    [SerializeField] private TextMeshProUGUI adver_txt;
    [SerializeField] private TextMeshProUGUI time_txt;
    [SerializeField] private TextMeshProUGUI finalTime_txt;

    [SerializeField] private List<GameObject> spawnPointsList = new List<GameObject>();
    [SerializeField] private List<GameObject> lifePlayerList = new List<GameObject>();

    public Bolsa_Player player;
    public GameObject enemy;
    public Vector2 enemyPos;

    public AudioClip audioButton;
    public AudioClip audioPowerUpDoubleJump;
    public AudioClip songPhase;
    public AudioClip songGameOver;
    public AudioClip songVictory;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        inicialScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        finalScreen.SetActive(false);

        currentSpawnPoint = -1;
        qtyCurrentDoc = 0;
        qtyCurrentGoldenDoc = 0;
        qtyTotalLifePlayer = 3;
        qtyLifePlayer = qtyTotalLifePlayer;
        lifePlayerList[3].SetActive(true);
        Time.timeScale = 0;
        gameRunning = false;

        seconds = 0;
        minutes = 0;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Bolsa_Player>();
        player.transform.position = spawnPointsList[0].transform.position;
    }

    private void Update()
    {
        if (gameRunning)
        {
            seconds += Time.deltaTime;

            if (seconds > 59)
            {
                minutes++;
                seconds = 0;
            }

            time_txt.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void StartGame()
    {
        inicialScreen.SetActive(false);
        Time.timeScale = 1;
        player.controlsEnabled = true;
        gameRunning = true;
        enemy.GetComponent<Bolsa_Enemy>().SetSpeed(ArraySpeedEnemy[0]);
        Bolsa_AudioManager.audioManager.PlayOneShot(audioButton, 1);
        Bolsa_AudioManager.audioManager.PlaySong(songPhase, true);
    }

    public void VictoryGame()
    {
        gameRunning = false;
        if (enemy.GetComponent<Bolsa_Enemy>() != null)
            enemy.GetComponent<Bolsa_Enemy>().SetSpeed(0);

        player.controlsEnabled = false;
        finalScreen.SetActive(true);
        qtyDocWinScreen_txt.text = qtyCurrentDoc.ToString() + " / 20";
        qtyGoldenDocWinScreen_txt.text = qtyCurrentGoldenDoc.ToString() + " / 10";
        finalTime_txt.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        xp = (int)((50 + qtyCurrentDoc + 4 * qtyCurrentGoldenDoc) * (120 / ((minutes * 60) + seconds)));
        xp_txt.text = "XP: " + ((int)xp).ToString();
        GameManagerGeneral.instance.SetXPPlayer(xp);

        finalMsgGood_txt.SetActive(false);
        finalMsgBad_txt.SetActive(false);

        if (qtyCurrentDoc == qtyTotalDoc)
        {
            finalMsgGood_txt.SetActive(true);
            percBolsa_txt.text = "Porcentagem de Bolsa: " + ((float)qtyCurrentGoldenDoc / (float)qtyTotalGoldenDoc * 100.00).ToString() + "%";
            adver_txt.text = "Como é bom receber uma bolsa, não é mesmo?!Aqui no Inatel também oferecemos bolsas de estudos de 20 % a 100 % para nossos alunos, venha e confira;)";
            Bolsa_AudioManager.audioManager.PlaySong(songVictory, false);
            PlayerPrefs.SetInt("Corrida dos Documentos", 1);
        }
        else
        {
            finalMsgBad_txt.SetActive(true);
            percBolsa_txt.text = "Porcentagem de Bolsa: 0%";
            adver_txt.text = "Oh não :( Você não conseguiu coletar todos os documentos necessários, mas não se preocupa pois você poderá tentar novamente! Aqui no Inatel oferecemos também oferecemos bolsa de estudos, venha e confira ;)";
            Bolsa_AudioManager.audioManager.PlaySong(songGameOver, false);
        }

        CheckAchievements();
    }

    private void CheckAchievements()
    {
        if (qtyCurrentDoc == qtyTotalDoc)
        {
            PlayerPrefs.SetInt("Muita Papelada...", 1);
        }

        if (qtyCurrentDoc == qtyTotalDoc - 1 && qtyCurrentGoldenDoc >= 5)
        {
            PlayerPrefs.SetInt("Documentacao Pendente...", 1);
        }

        if (qtyCurrentDoc == qtyTotalDoc && qtyCurrentGoldenDoc == qtyTotalGoldenDoc && qtyLifePlayer == qtyTotalLifePlayer && ((minutes * 60) + seconds) < 120)
        {
            PlayerPrefs.SetInt("Mestre dos Descontos FINATEL", 1);
        }
    }

    public void RestartGame()
    {
        Bolsa_AudioManager.audioManager.PlayOneShot(audioButton, 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackMenu()
    {
        Bolsa_AudioManager.audioManager.PlayOneShot(audioButton, 1);
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        //Time.timeScale = 0;
        gameRunning = false;
        gameOverScreen.SetActive(true);
        Bolsa_AudioManager.audioManager.PlaySong(songGameOver, false);
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

    public void SpawnsController(string spawnName)
    {
        currentSpawnPoint++;
        enemy.GetComponent<Bolsa_Enemy>().SetSpeed(ArraySpeedEnemy[currentSpawnPoint]);

        enemyPos = new Vector2(enemy.transform.position.x, enemy.transform.position.y);

        if (spawnName == "Spawn2_PUp")
        {
            player.canDoubleJump = true;
            Bolsa_AudioManager.audioManager.PlayOneShot(audioPowerUpDoubleJump, 1);
        }
    }

    public void RespawnByDeath()
    {
        player.transform.position = spawnPointsList[currentSpawnPoint].transform.position;
        enemy.transform.position = enemyPos;
        Bolsa_AudioManager.audioManager.PlayOneShot(player.audioHit, 1);

        for (int i = 0; i < lifePlayerList.Count; i++)
        {
            lifePlayerList[i].SetActive(false);
        }

        qtyLifePlayer--;
        lifePlayerList[qtyLifePlayer].SetActive(true);

        if (qtyLifePlayer <= 0)
        {
            StartCoroutine(DiePlayer());
        }
    }

    public IEnumerator DiePlayer()
    {
        gameRunning = false;
        Bolsa_AudioManager.audioManager.PlayOneShot(player.audioHit, 1);
        if (enemy.GetComponent<Bolsa_Enemy>() != null)
            enemy.GetComponent<Bolsa_Enemy>().SetSpeed(0);
        player.GetComponent<Bolsa_Player>().PlayerDie();
        yield return new WaitForSeconds(1f);
        GameOver();
    }

}
