using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Playercontroller playerControllerScript;
    public DetectCollision detectCollision;

    public int score;

    public GameObject[] obstaclePrefabs;
    public Transform[] spawnPoints;

    private Vector3 spawnPos;
   

    private float timeIniciate = 2f;
    private float timeDelay = 1f;

    private bool scorebool1 = true;
    private bool scorebool2 = true;
    private bool scorebool3 = true;
    private bool scorebool4 = true;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextGameOver;
    public TextMeshProUGUI maxScore;

    public string maxScoreString;


    public GameObject gameOverPanel;
    public GameObject scorePanel;
    public GameObject livesPanel;

    public AudioClip loseClip;
    public AudioSource gameManagerAudioSource;

    // public GameObject camara;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();

         InvokeRepeating("spawnear", timeIniciate, timeDelay);

        gameManagerAudioSource.GetComponent<AudioSource>();
        score = 0;
        gameOverPanel.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = $"Score {score} ";
        scoreTextGameOver.text = $"Score {score} ";

        maxScore.text = $"Max Score {maxScoreString}";

        //maxScore.text = $"Max Score [MaxScore] ";

        if ( score >= 100 && scorebool1 == true)
        {
            CancelInvoke();
            timeIniciate = 2f;
            timeDelay = 1.5f;
            InvokeRepeating("spawnear", timeIniciate, timeDelay);
            scorebool1 = false;
            Debug.Log(message: $" tienes {score} puntos");
        }

        if (score >= 200 && scorebool2 == true)
        {
            CancelInvoke();
            timeIniciate = 1f;
            timeDelay = 1f;
            InvokeRepeating("spawnear", timeIniciate, timeDelay);
            scorebool2 = false;
            Debug.Log(message: $" tienes {score} puntos");
        }
         if (score >= 500 && scorebool3 == true)
        {

            CancelInvoke();
            timeIniciate = 1f;
            timeDelay = 0.8f;
            InvokeRepeating("spawnear", timeIniciate, timeDelay);
            scorebool3 = false;
            Debug.Log(message: $" tienes {score} puntos");
        }
        if (score >= 1000 && scorebool4 == true)
        {
            CancelInvoke();
            timeIniciate = 1f;
            timeDelay = 0.5f;
            InvokeRepeating("spawnear", timeIniciate, timeDelay);
            scorebool4 = false;
            Debug.Log(message: $" tienes {score} puntos");

        }

        if (playerControllerScript.gameOver == true)
        {

            gameOverPanel.SetActive(true);
            scorePanel.SetActive(false);
            livesPanel.SetActive(false);
            //tu_variable_del_text.SetText(PlayerPrefs.GetInt("MaxScore"));
            
            maxScoreString = PlayerPrefs.GetInt("MaxScore").ToString();


            gameManagerAudioSource.PlayOneShot(loseClip, 0.03f);
        }

    }


    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = $"Score {score}";
        if(score > PlayerPrefs.GetInt("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", score);

           

        }
    }


    public void RemovePoints (int Points)
    {
        PlayerPrefs.SetInt("MaxScore", 0);

    }


    void spawnear()
    {
        if (playerControllerScript.gameOver == false)
        {
            int S = Random.Range(0, 3);
            int i = Random.Range(0, 21);
            Instantiate(obstaclePrefabs[S], spawnPoints[i].position, obstaclePrefabs[0].transform.rotation);

        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
