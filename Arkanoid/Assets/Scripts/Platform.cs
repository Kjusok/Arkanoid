using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _rightBorder;
    [SerializeField] private float _leftBorder;
    [SerializeField] private GameObject _stickyPlatform;
    [SerializeField] private GameObject _rightGunsOnPlatform;
    [SerializeField] private GameObject _leftGunsOnPlatform;
    private bool _switch = true;
    private Vector3 _playerPosition;

    public double RengthOfAppliedForce = 15.71;
    public float PlayerSpeed;
    public float TimeForStickyPlatform;
    public float TimeForActivGuns;
    public Vector2 PlatformPlayer;
    public float PlatformCentr;
    public int SizeOfPlatform;

    private void Start()
    {
        SizeOfPlatform = 0;
        _playerPosition = transform.position;
    }
    public void TakeTimeForStickyPlatform(int _time)
    {
        TimeForStickyPlatform += _time;
        if (TimeForStickyPlatform > 0)
        {
            _stickyPlatform.SetActive(true);
        }
    }
    public void TakeTimeForGuns(int _time)
    {
        TimeForActivGuns += _time;
        if (TimeForActivGuns > 0)
        {
            _rightGunsOnPlatform.SetActive(true);
            _leftGunsOnPlatform.SetActive(true);
        }
    }
    private void OffGunsOnPlatform()
    {
        if (TimeForActivGuns <= 0)
        {
            _rightGunsOnPlatform.SetActive(false);
            _leftGunsOnPlatform.SetActive(false);
        }
        if (TimeForActivGuns > 0)
        {
            TimeForActivGuns -= Time.deltaTime;
        }
    }
    private void OffStickyPlatform()
    {
        if (TimeForStickyPlatform <= 0)
        {
            _stickyPlatform.SetActive(false);
        }
        if (TimeForStickyPlatform > 0)
        {
            TimeForStickyPlatform -= Time.deltaTime;
        }
    }
    public void TakeChangePlatformSize(int _size)
    {
        SizeOfPlatform += _size;
    }
    public void CheckSizeOfPlatform()
    {
        if (SizeOfPlatform > 3)
        {
            SizeOfPlatform = 3;
        }
        if (SizeOfPlatform < -2)
        {
            SizeOfPlatform = -2;
        }
    }
    public void ChangePlatformSize()
    {
        if (SizeOfPlatform == -2)
        {
            PlatformPlayer = new Vector2(60, 100);
            transform.localScale = PlatformPlayer;
            _rightBorder = 1778;
            _leftBorder = 142;
        }
        if (SizeOfPlatform == -1)
        {
            PlatformPlayer = new Vector2(80, 100);
            transform.localScale = PlatformPlayer;
            _rightBorder = 1755;
            _leftBorder = 165;
        }
        if (SizeOfPlatform == 0)
        {
            PlatformPlayer = new Vector2(100, 100);
            transform.localScale = PlatformPlayer;
            _rightBorder = 1730;
            _leftBorder = 190;
        }
        if (SizeOfPlatform == 1)
        {
            PlatformPlayer = new Vector2(130, 100);
            transform.localScale = PlatformPlayer;
            _rightBorder = 1695;
            _leftBorder = 225;
        }
        if (SizeOfPlatform == 2)
        {
            PlatformPlayer = new Vector2(160, 100);
            transform.localScale = PlatformPlayer;
            _rightBorder = 1658;
            _leftBorder = 262;
        }
        if (SizeOfPlatform == 3)
        {
            PlatformPlayer = new Vector2(180, 100);
            transform.localScale = PlatformPlayer;
            _rightBorder = 1635;
            _leftBorder = 285;
        }
    }
    public void ChangeForceDependingOnLengthOfPlatform()
    {
        if (SizeOfPlatform == -2)
        {
            RengthOfAppliedForce = 15.71 - 15.71 * 0.4;
        }
        if (SizeOfPlatform == -1)
        {
            RengthOfAppliedForce = 15.71 - 15.71 * 0.2;
        }
        if (SizeOfPlatform == 0)
        {
            RengthOfAppliedForce = 15.71;
        }
        if (SizeOfPlatform == 1)
        {
            RengthOfAppliedForce = 15.71 + 15.71 * 0.3;
        }
        if (SizeOfPlatform == 2)
        {
            RengthOfAppliedForce = 15.71 + 15.71 * 0.6;
        }
        if (SizeOfPlatform == 3)
        {
            RengthOfAppliedForce = 15.71 + 15.71 * 0.8;
        }
    }
    private void Update()
    {
        CheckSizeOfPlatform();
        ChangePlatformSize();
        ChangeForceDependingOnLengthOfPlatform();
        OffStickyPlatform();
        OffGunsOnPlatform();
        if (Player.GameIsPaused == false)
        {
            _playerPosition.x += Input.GetAxis("Horizontal") * PlayerSpeed;
            transform.position = _playerPosition;
        }
        if (_playerPosition.x < _leftBorder)
        {
            transform.position = new Vector3(_leftBorder, _playerPosition.y, _playerPosition.z);
            _playerPosition.x = _leftBorder;
        }
        if (_playerPosition.x > _rightBorder)
        {
            transform.position = new Vector3(_rightBorder, _playerPosition.y, _playerPosition.z);
            _playerPosition.x = _rightBorder;
        }
    }
    private void OnCollisionEnter2D(Collision2D contact)
    {
        if (TimeForStickyPlatform > 0)
        {
            if (contact.gameObject.tag == "Ball")
            {
                contact.gameObject.GetComponent<Ball>().OnStickyPlatform(_switch); ;
            }
        }
    }
}

