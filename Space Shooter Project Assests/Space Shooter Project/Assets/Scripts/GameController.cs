using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text restartText;
    public Text gameOverText;
    public Text scoreText;

    private bool gameOver;
    private bool restart;
    private int score;

    public AudioSource musicSource;
    public AudioClip musicClipTwo;
    void Start ()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
 
        StartCoroutine (SpawnWaves());
        musicSource.clip = musicClipTwo;
        musicSource.Play();
    }

    void Update ()
    {
        SceneManager.LoadScene("Sample Scene");
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
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
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
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
        scoreText.text = "Score:" + score;
    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

}


