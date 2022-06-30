using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int _score;
    public int _healthOfPlayer;

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
}
