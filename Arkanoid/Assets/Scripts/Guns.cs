using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private float _rightBorderForGun;
    [SerializeField] private float _leftBorderForGun;
    [SerializeField] private bool _leftGun;
    [SerializeField] private bool _rightGun;
    [SerializeField] private GameObject[] _bullet;
    private Vector3 _gunPosition;
    private Vector2 _positionOfBullet;

    public Platform PlayerSpeed;
    public Platform SizeOfPlatform;

    void Start()
    {
        _gunPosition = transform.position;
    }
    private void FireToGuns()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _positionOfBullet = this.gameObject.transform.position;
            Instantiate(_bullet[0], _positionOfBullet, Quaternion.Euler(0, 0, 90));
        }
    }
    private void ChangePositionForLeftGun()
    {
        if (SizeOfPlatform.SizeOfPlatform == -2 && _leftGun)
        {
            _gunPosition.x = _playerObject.transform.position.x - 60;
            _rightBorderForGun = 1718;
        }
        if (SizeOfPlatform.SizeOfPlatform == -1 && _leftGun)
        {
            _gunPosition.x = _playerObject.transform.position.x - 80;
            _rightBorderForGun = 1675;
        }
        if (SizeOfPlatform.SizeOfPlatform == 0 && _leftGun)
        {
            _gunPosition.x = _playerObject.transform.position.x - 100;
            _rightBorderForGun = 1630;
        }
        if (SizeOfPlatform.SizeOfPlatform == 1 && _leftGun)
        {
            _gunPosition.x = _playerObject.transform.position.x - 130;
            _rightBorderForGun = 1565;
            _leftBorderForGun = 95;
        }
        if (SizeOfPlatform.SizeOfPlatform == 2 && _leftGun)
        {
            _gunPosition.x = _playerObject.transform.position.x - 160;
            _rightBorderForGun = 1498;
            _leftBorderForGun = 102;

        }
        if (SizeOfPlatform.SizeOfPlatform == 3 && _leftGun)
        {
            _gunPosition.x = _playerObject.transform.position.x - 180;
            _rightBorderForGun = 1455;
            _leftBorderForGun = 105;
        }
    }
    private void ChangePositionForRightGun()
    {
        if (SizeOfPlatform.SizeOfPlatform == -2 && _rightGun)
        {
            _gunPosition.x = _playerObject.transform.position.x + 60;
            _leftBorderForGun = 202;
        }
        if (SizeOfPlatform.SizeOfPlatform == -1 && _rightGun)
        {
            _gunPosition.x = _playerObject.transform.position.x + 80;
            _leftBorderForGun = 245;
        }
        if (SizeOfPlatform.SizeOfPlatform == 0 && _rightGun)
        {
            _gunPosition.x = _playerObject.transform.position.x + 100;
            _leftBorderForGun = 290;
        }
        if (SizeOfPlatform.SizeOfPlatform == 1 && _rightGun)
        {
            _gunPosition.x = _playerObject.transform.position.x + 130;
            _leftBorderForGun = 355;
        }
        if (SizeOfPlatform.SizeOfPlatform == 2 && _rightGun)
        {
            _gunPosition.x = _playerObject.transform.position.x + 160;
            _leftBorderForGun = 422;
            _rightBorderForGun = 1818;
        }
        if (SizeOfPlatform.SizeOfPlatform == 3 && _rightGun)
        {
            _gunPosition.x = _playerObject.transform.position.x + 180;
            _leftBorderForGun = 465;
            _rightBorderForGun = 1815;
        }
    }
    void Update()
    {
        ChangePositionForLeftGun();
        ChangePositionForRightGun();
        FireToGuns();
        if (Player.GameIsPaused == false && _leftGun)
        {
            _gunPosition.x += Input.GetAxis("Horizontal") * PlayerSpeed.PlayerSpeed;
            transform.position = _gunPosition;
        }
        if (_gunPosition.x < _leftBorderForGun)
        {
            transform.position = new Vector3(_leftBorderForGun, _gunPosition.y, _gunPosition.z);
            _gunPosition.x = _leftBorderForGun;
        }
        if (_gunPosition.x > _rightBorderForGun)
        {
            transform.position = new Vector3(_rightBorderForGun, _gunPosition.y, _gunPosition.z);
            _gunPosition.x = _rightBorderForGun;
        }

        if (Player.GameIsPaused == false && _rightGun)
        {
            _gunPosition.x += Input.GetAxis("Horizontal") * PlayerSpeed.PlayerSpeed;
            transform.position = _gunPosition;
        }
        if (_gunPosition.x < _leftBorderForGun)
        {
            transform.position = new Vector3(_leftBorderForGun, _gunPosition.y, _gunPosition.z);
            _gunPosition.x = _leftBorderForGun;
        }
        if (_gunPosition.x > _rightBorderForGun)
        {
            transform.position = new Vector3(_rightBorderForGun, _gunPosition.y, _gunPosition.z);
            _gunPosition.x = _rightBorderForGun;
        }
    }
}
