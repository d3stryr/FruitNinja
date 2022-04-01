using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;
    public Button bt;

    [Header("Sounds")]
    public AudioClip[] sliceSounds;

    private AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        GethighScore();
    }
    private void GethighScore()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        HighScoreText.text = "Best : "+highScore.ToString();
    }

    public void IncreaseScore(int addedPoints)
    {
        score += addedPoints;
        scoreText.text = score.ToString();

        if(score>highScore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            HighScoreText.text = "Best : "+score.ToString();
        }
    }

    public void OnBombHit()
    {
        Debug.Log("Bomb Hit");
        bt.gameObject.SetActive(true);
        Time.timeScale = 0;


    }
    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        
    }

    public void PlayRandomSliceSound()
    {
        AudioClip randomSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audiosource.PlayOneShot(randomSound);
    }
}
