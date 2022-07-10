using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private int _score;

    public static int HealthOfPlayer;
    public static GameObject[] Health;
    public static bool GameIsPaused = false;

    public Platform SpeedOfPlatform;
    public GameObject PauseMenu;

    void Start()
    {
        _score = 0;
        HealthOfPlayer = 3;
    }
    public void AddPoints(int _points)
    {
        _score += _points;
        string scoreTextWithZero = string.Format("{0:D9}", _score);
        _scoreText.text = scoreTextWithZero;
    }
    public void TakeAwayHealth(int _healthThatIsLose)
    {
        HealthOfPlayer -= _healthThatIsLose;
        if (HealthOfPlayer >= 0)
        {
            Health = GameObject.FindGameObjectsWithTag("Health Player");
            Destroy(Health[Health.Length-1]);
        }
    }
    public void HealthUp(int _healthThatIsTaken)
    {
        if (HealthOfPlayer < 5)
        {
            HealthOfPlayer += _healthThatIsTaken;
        }
    }
   
    
    public void DestroyBall()
    {
        if (HealthOfPlayer == 0)
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
