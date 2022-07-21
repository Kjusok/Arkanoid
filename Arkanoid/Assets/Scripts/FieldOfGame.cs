using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfGame : MonoBehaviour
{
    [SerializeField] private GameObject _shieldFloor;
    [SerializeField] private SpriteRenderer _spriteOfShieldFloor;
    public float TimeForTurnOnShieldFloor;

    void Start()
    {
        TimeForTurnOnShieldFloor = 0;
    }
    public void TakeTimeForShieldFloor(int _time)
    {
        TimeForTurnOnShieldFloor += _time;
        if (TimeForTurnOnShieldFloor > 0)
        {
            _shieldFloor.SetActive(true);
        }
    }
    void Update()
    {
        if (TimeForTurnOnShieldFloor <= 0)
        {
            _shieldFloor.SetActive(false);
        }
        if (TimeForTurnOnShieldFloor > 0)
        {
            TimeForTurnOnShieldFloor -= Time.deltaTime;
        }
        if (TimeForTurnOnShieldFloor < 4 && TimeForTurnOnShieldFloor > 3)
        {
            Color NewColor = new Color(1,1,1,0);
            _spriteOfShieldFloor.color = NewColor;
        }
        if (TimeForTurnOnShieldFloor < 3 && TimeForTurnOnShieldFloor > 2)
        {
            Color NewColor = new Color(1, 1, 1, 1);
            _spriteOfShieldFloor.color = NewColor;
        }
        if (TimeForTurnOnShieldFloor < 2 && TimeForTurnOnShieldFloor > 1)
        {
            Color NewColor = new Color(1, 1, 1, 0);
            _spriteOfShieldFloor.color = NewColor;
        }
        if (TimeForTurnOnShieldFloor < 1 && TimeForTurnOnShieldFloor > 0)
        {
            Color NewColor = new Color(1, 1, 1, 1);
            _spriteOfShieldFloor.color = NewColor;
        }
    }
}
