using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbodyOfBall;
    [SerializeField] private GameObject playerObject;
    public float PowerBall;
    public bool BallIsActive;

    private readonly int _healthThatIsLose = 1;
    private Vector2 _ballPosition;

    private void Start()
    {
        BallIsActive = false;
        _ballPosition = transform.position;
    }
    public void TakeIncreaseSpeedOfBall(int _speedOfBall)
    {
        PowerBall += _speedOfBall;
        
        if (PowerBall == 80)
        {
            _rigidbodyOfBall.velocity = new Vector2(Mathf.Round(_rigidbodyOfBall.velocity.x * 1.334f), Mathf.Round(_rigidbodyOfBall.velocity.y * 1.334f));
        }
        if (PowerBall == 100)
        {
            _rigidbodyOfBall.velocity = new Vector2(_rigidbodyOfBall.velocity.x * 1.25f, _rigidbodyOfBall.velocity.y * 1.25f);
        }
        if (PowerBall == 120)
        {
            _rigidbodyOfBall.velocity = new Vector2(_rigidbodyOfBall.velocity.x * 1.2f, _rigidbodyOfBall.velocity.y * 1.2f);
        }
        if (PowerBall == 140)
        {
            _rigidbodyOfBall.velocity = new Vector2(Mathf.Round(_rigidbodyOfBall.velocity.x * 1.1667f), Mathf.Round(_rigidbodyOfBall.velocity.y * 1.1667f));
        }
        if (PowerBall == 160)
        {
            _rigidbodyOfBall.velocity = new Vector2(Mathf.Round(_rigidbodyOfBall.velocity.x * 1.143f), Mathf.Round(_rigidbodyOfBall.velocity.y * 1.143f));
        }
        if (PowerBall == 180)
        {
            _rigidbodyOfBall.velocity = new Vector2(_rigidbodyOfBall.velocity.x * 1.125f, _rigidbodyOfBall.velocity.y * 1.125f);
        }
    }

    public void TakeDecreaseSpeedOfBall(int _speedOfBall)
    {
        PowerBall -= _speedOfBall;
        if (PowerBall == 60)
        {
            _rigidbodyOfBall.velocity = new Vector2(_rigidbodyOfBall.velocity.x * 0.75f, _rigidbodyOfBall.velocity.y * 0.75f);
        }
        if (PowerBall == 80)
        {
            _rigidbodyOfBall.velocity = new Vector2(Mathf.Round(_rigidbodyOfBall.velocity.x * 0.8f), Mathf.Round(_rigidbodyOfBall.velocity.y * 0.8f));
        }
        if (PowerBall == 100)
        {
            _rigidbodyOfBall.velocity = new Vector2(Mathf.Round(_rigidbodyOfBall.velocity.x * 0.8336f), Mathf.Round(_rigidbodyOfBall.velocity.y * 0.8336f));
        }
        if (PowerBall == 120)
        {   _rigidbodyOfBall.velocity = new Vector2(Mathf.Round(_rigidbodyOfBall.velocity.x * 0.8572f), Mathf.Round(_rigidbodyOfBall.velocity.y * 0.8572f));
        }
        if (PowerBall == 140)
        {
            _rigidbodyOfBall.velocity = new Vector2(_rigidbodyOfBall.velocity.x * 0.875f, _rigidbodyOfBall.velocity.y * 0.875f);
        }
        if (PowerBall == 160)
        {
            _rigidbodyOfBall.velocity = new Vector2(Mathf.Round(_rigidbodyOfBall.velocity.x * 0.889f), Mathf.Round(_rigidbodyOfBall.velocity.y * 0.889f));
        }
    }

    public void CheckMaxOrMinSpeedOfBall()
    {
        if (PowerBall > 180)
        {
            PowerBall = 180;
        }
        if (PowerBall < 60)
        {
            PowerBall = 60;
        }
    }
    private void Update()
    {
        CheckMaxOrMinSpeedOfBall();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(_rigidbodyOfBall.velocity.x);
            if (BallIsActive == false)
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
            player.gameObject.GetComponent<Player>().TakeAwayHealth(_healthThatIsLose);

            BallIsActive = false;
            _ballPosition.x = playerObject.transform.position.x;
            _ballPosition.y = 82f;
            transform.position = _ballPosition;
        }
    }
}
