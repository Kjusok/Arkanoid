using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfGame : MonoBehaviour
{
    [SerializeField] private GameObject _shieldFloor;
    [SerializeField] private SpriteRenderer _spriteOfShieldFloor;
    public float _timeForTurnOnShieldFloor;

    void Start()
    {
        _timeForTurnOnShieldFloor = 0;
    }
    public void TakeTimeForShieldFloor(int _time)
    {
        _timeForTurnOnShieldFloor += _time;
        if (_timeForTurnOnShieldFloor > 0)
        {
            _shieldFloor.SetActive(true);
        }
    }
    void Update()
    {
        if (_timeForTurnOnShieldFloor <= 0)
        {
            _shieldFloor.SetActive(false);
        }
        if (_timeForTurnOnShieldFloor > 0)
        {
            _timeForTurnOnShieldFloor -= Time.deltaTime;
        }
        if (_timeForTurnOnShieldFloor < 4 && _timeForTurnOnShieldFloor > 3)
        {
            Color NewColor = new Color(1,1,1,0);
            _spriteOfShieldFloor.color = NewColor;
        }
        if (_timeForTurnOnShieldFloor < 3 && _timeForTurnOnShieldFloor > 2)
        {
            Color NewColor = new Color(1, 1, 1, 1);
            _spriteOfShieldFloor.color = NewColor;
        }
        if (_timeForTurnOnShieldFloor < 2 && _timeForTurnOnShieldFloor > 1)
        {
            Color NewColor = new Color(1, 1, 1, 0);
            _spriteOfShieldFloor.color = NewColor;
        }
        if (_timeForTurnOnShieldFloor < 1 && _timeForTurnOnShieldFloor > 0)
        {
            Color NewColor = new Color(1, 1, 1, 1);
            _spriteOfShieldFloor.color = NewColor;
        }
    }
}
