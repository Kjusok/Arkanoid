using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int _score;
    private int _healthOfPlayer;

    public Platform SpeedOfPlatform;
    public GameObject PauseMenu;
    public static bool GameIsPaused = false;


    void Start()
    {
        _score = 0;
        _healthOfPlayer = 5;
    }
    public void AddPoints(int _points)
    {
        _score += _points;
        string scoreTextWithZero = string.Format("{0:D9}", _score);
        _scoreText.text = scoreTextWithZero;
    }
    public void TakeAwayHealth(int _health)
    {
        _healthOfPlayer -= _health;
        if (_healthOfPlayer >= 0)
        {
            GameObject[] Health;
            Health = GameObject.FindGameObjectsWithTag("Health Player");
            Destroy(Health[0]);
        }
    }
    public void DestroyBall()
    {
        if (_healthOfPlayer == 0)
        {
            GameObject Balls;
            Balls = GameObject.FindGameObjectWithTag("Ball");
            Destroy(Balls);

            SpeedOfPlatform.PlayerSpeed = 0;

            PauseMenu.SetActive(true);
        }
    }
    public void PressRestartButton()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("FirstLevel");
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Load scene menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    private void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    private void Update()
    {
        DestroyBall();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
