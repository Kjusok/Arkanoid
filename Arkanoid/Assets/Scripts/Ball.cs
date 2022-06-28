using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbodyOfBall;
    [SerializeField] private GameObject playerObject;
    [SerializeField] public float _powerBall;
    [SerializeField] public bool _ballIsActive;

    private Vector2 _ballPosition;

    private void Start()
    {
        _ballIsActive = false;
        _ballPosition = transform.position;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_ballIsActive==false)
            {
                _ballIsActive = true;
                _rigidbodyOfBall.AddForce(new Vector2(Mathf.Abs(0.005f * _powerBall), 0.055f * _powerBall));
                _rigidbodyOfBall.freezeRotation = true;

            }
        }
        if (_ballIsActive == false)
        {
            _rigidbodyOfBall.velocity = new Vector2(0, 0);
            _ballPosition.x = playerObject.transform.position.x;
            transform.position = _ballPosition;
        }
        if (transform.position.y < -15f)
        {
            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag("Health Player");
            Destroy(gameObjects[0]);

            _ballIsActive = false;
            _ballPosition.x = playerObject.transform.position.x;
            _ballPosition.y = 82f;
            transform.position = _ballPosition;
           
            
        }
        
    }
}
