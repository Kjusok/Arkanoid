using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbodyOfBall;
    [SerializeField] private GameObject playerObject;
    [SerializeField] public float PowerBall;
    [SerializeField] public bool BallIsActive;
    private int _health = 1;

    private Vector2 _ballPosition;

    private void Start()
    {
        BallIsActive = false;
        _ballPosition = transform.position;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (BallIsActive==false)
            {
                BallIsActive = true;
                _rigidbodyOfBall.AddForce(new Vector2(Mathf.Abs(0.005f * PowerBall), 0.055f * PowerBall));
                _rigidbodyOfBall.freezeRotation = true;
            }
        }
        if (BallIsActive == false)
        {
            _rigidbodyOfBall.velocity = new Vector2(0, 0);
            _ballPosition.x = playerObject.transform.position.x;
            transform.position = _ballPosition;
        }
        if (transform.position.y < -15f)
        {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.gameObject.GetComponent<Player>().TakeAwayHealth(_health);

            //GameObject[] Health;
            //Health = GameObject.FindGameObjectsWithTag("Health Player");
            //Destroy(Health[0]);

            BallIsActive = false;
            _ballPosition.x = playerObject.transform.position.x;
            _ballPosition.y = 82f;
            transform.position = _ballPosition;
        }
    }
}
