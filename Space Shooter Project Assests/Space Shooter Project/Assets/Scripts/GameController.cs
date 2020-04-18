using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text restartText;
    public Text gameOverText;
    public Text scoreText;
    public Text winText;


    private bool gameOver;
    private bool restart;
    public int score;

    public Text livesText;
    public int lives;

    public AudioSource musicSource;
    public AudioClip musicClipTwo;
    public AudioClip musicClipWin;
    public AudioClip musicClipLose;

    void Start ()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
 
        StartCoroutine (SpawnWaves());
        musicSource.clip = musicClipTwo;
        musicSource.Play();

        lives = 3;
        SetLivesText();
    }

    void Update ()
    {
        //SceneManager.LoadScene("Sample Scene");
        if(restart)
        {
            
            
            if (Input.GetKeyDown (KeyCode.G))
            {
                SceneManager.LoadScene("SampleScene");
            }

            
        }
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            if (score >= 40)
            {
                hazardCount = 15;
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'G' for Restart";
                restart = true;
                break;
            }
        }

    }
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore ()
    {
        scoreText.text = "Points:" + score;
        if (score >= 100)
        {

                winText.text = "You win!, game created by Dwight Waller.";
                gameOver = true;
                restart = true;

            musicSource.clip = musicClipTwo;
            musicSource.Stop();

            musicSource.clip = musicClipWin;
            musicSource.Play();



        }
        else if(lives == 0)
        {
            void GameOver()
            {
                gameOverText.text = "Game Over!, game created by Dwight Waller.";
                gameOver = true;

            }
        }
    }
     public void SetLivesText()
    {
        livesText.text = "lives: " + lives.ToString();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
              lives = lives - 1;
            SetLivesText();
        }
    }


        public void GameOver ()
         {
         gameOverText.text = "Game Over!, game created by Dwight Waller.";
         gameOver = true;
        musicSource.clip = musicClipTwo;
        musicSource.Stop();

        musicSource.clip = musicClipLose;
        musicSource.Play();

    }

        void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }


}


