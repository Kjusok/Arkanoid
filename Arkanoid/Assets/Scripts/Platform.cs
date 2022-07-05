using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] public float PlayerSpeed;
    [SerializeField] private float _rightBorder;
    [SerializeField] private float _leftBorder;
    [SerializeField] private BoxCollider2D _platform;

    private Vector3 _playerPosition;
    private double _lengthOfAppliedForce = 15.71;
    public Ball PowerOfBall;
    public Ball ActiveBall;

    private void Start()
    {
        _playerPosition = transform.position;
    }
    private void Update()
    {
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
        if(contact.gameObject.tag == "Ball" && ActiveBall.BallIsActive)
        {
            Rigidbody2D ballRb = contact.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = contact.contacts[0].point;
            Vector3 platformCenter = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

            ballRb.velocity = Vector2.zero;
           // Debug.Log(ballRb.velocity);
            //Debug.Log("Точка колизии" + hitPoint.x);

            float difference = platformCenter.x - hitPoint.x;
           // Debug.Log("Платформа - точка колизии" + difference);

            if (difference > 0 && difference < _lengthOfAppliedForce)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(0.005f * PowerOfBall.PowerBall)), 0.055f * PowerOfBall.PowerBall));
                Debug.Log("1-" + difference);
            }
            if (difference > _lengthOfAppliedForce && difference < _lengthOfAppliedForce * 2)
            {
                ballRb.AddForce(new Vector2(-Mathf.Abs(0.01f * PowerOfBall.PowerBall), 0.05f * PowerOfBall.PowerBall));
                Debug.Log("2-" + difference);
            }
            if (difference > _lengthOfAppliedForce * 2 && difference < _lengthOfAppliedForce*3)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(0.02f * PowerOfBall.PowerBall)), 0.04f * PowerOfBall.PowerBall));
                Debug.Log("3-" + difference);
            }
            if (difference > _lengthOfAppliedForce * 3 && difference < _lengthOfAppliedForce * 4)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(0.03f * PowerOfBall.PowerBall)), 0.03f * PowerOfBall.PowerBall));
                Debug.Log("4-" + difference);
            }
            if (difference > _lengthOfAppliedForce * 4 && difference < _lengthOfAppliedForce * 5)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(0.04f * PowerOfBall.PowerBall)), 0.02f * PowerOfBall.PowerBall));
                Debug.Log("5-" + difference);
            }
            if (difference > _lengthOfAppliedForce * 5 && difference < _lengthOfAppliedForce * 6)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(0.05f * PowerOfBall.PowerBall)), 0.01f * PowerOfBall.PowerBall));
                Debug.Log("6-" + difference);
            }
            if (difference > _lengthOfAppliedForce * 6 && difference < _lengthOfAppliedForce * 7.1)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(0.055f * PowerOfBall.PowerBall)), 0.005f * PowerOfBall.PowerBall));
                Debug.Log("7-" + difference);
            }
            //Reverse
            if (difference < 0 && difference > -_lengthOfAppliedForce)
            {
                ballRb.AddForce(new Vector2(Mathf.Abs(0.005f * PowerOfBall.PowerBall), 0.055f * PowerOfBall.PowerBall));
                Debug.Log("+1-" + difference);
            }
            if (difference < -_lengthOfAppliedForce && difference > -_lengthOfAppliedForce * 2)
            {
                ballRb.AddForce(new Vector2(Mathf.Abs(0.01f * PowerOfBall.PowerBall), 0.05f * PowerOfBall.PowerBall));
                Debug.Log("+2-" + difference);
            }
            if (difference < -_lengthOfAppliedForce * 2 && difference > -_lengthOfAppliedForce * 3)
            {
                ballRb.AddForce(new Vector2(Mathf.Abs(0.02f * PowerOfBall.PowerBall), 0.04f * PowerOfBall.PowerBall));
                Debug.Log("+3-" + difference);
            }
            if (difference < -_lengthOfAppliedForce * 3 && difference > -_lengthOfAppliedForce * 4)
            {
                ballRb.AddForce(new Vector2(Mathf.Abs(0.03f * PowerOfBall.PowerBall), 0.03f * PowerOfBall.PowerBall));
                Debug.Log("+4-" + difference);
            }
            if (difference < -_lengthOfAppliedForce * 4 && difference > -_lengthOfAppliedForce * 5)
            {
                ballRb.AddForce(new Vector2(Mathf.Abs(0.04f * PowerOfBall.PowerBall), 0.02f * PowerOfBall.PowerBall));
                Debug.Log("+5-" + difference);
            }
            if (difference < -_lengthOfAppliedForce * 5 && difference > -_lengthOfAppliedForce * 6)
            {
                ballRb.AddForce(new Vector2(Mathf.Abs(0.05f * PowerOfBall.PowerBall), 0.01f * PowerOfBall.PowerBall));
                Debug.Log("+6-" + difference);
            }
            if (difference < -_lengthOfAppliedForce * 6 && difference > -_lengthOfAppliedForce * 7.1)
            {
                ballRb.AddForce(new Vector2(Mathf.Abs(0.055f * PowerOfBall.PowerBall), 0.005f * PowerOfBall.PowerBall));
                Debug.Log("+7-" + difference);
            }
        }
    }
}

