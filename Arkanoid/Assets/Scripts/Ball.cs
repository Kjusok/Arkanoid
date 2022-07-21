using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbodyOfBall;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject _ball;
    [SerializeField] private Vector2 _ballPosition;

    public Platform AppliedForce;
    public GameObject[] Balls;
    public int PowerBall;
    public bool BallIsActive;
    public bool BallIsStuck;

    private readonly int _healthThatIsLose = 1;
    private float _positionOfHitBall;
    private float _platformCentr;
    private void Start()
    {
          BallIsStuck = false;
        if (Balls.Length <1)
        {
            BallIsActive = false;
        }
        _ballPosition = transform.position;
    }
    public void SpawnBalls(Vector2 position)
    {
        GameObject spawnedBall = Instantiate(_ball, position, Quaternion.identity) as GameObject;
        Rigidbody2D spawnedBallRd = spawnedBall.GetComponent<Rigidbody2D>();
        if (_rigidbodyOfBall.velocity.x > 0 && _rigidbodyOfBall.velocity.y > 0)
        {
            spawnedBallRd.velocity = new Vector2(_rigidbodyOfBall.velocity.x - 200, _rigidbodyOfBall.velocity.y + 200);
        }
        else
        {
            spawnedBallRd.velocity = new Vector2(_rigidbodyOfBall.velocity.x + 200, _rigidbodyOfBall.velocity.y - 200);
        }
        if (_rigidbodyOfBall.velocity.x < 0 && _rigidbodyOfBall.velocity.y > 0)
        {
            spawnedBallRd.velocity = new Vector2(_rigidbodyOfBall.velocity.x - 200, _rigidbodyOfBall.velocity.y - 200);
        }
        else
        {
            spawnedBallRd.velocity = new Vector2(_rigidbodyOfBall.velocity.x + 200, _rigidbodyOfBall.velocity.y + 200);
        }
    }
    public void TakeMultyBall(bool _switch)
    {
        if (_switch)
        {
            Balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject i in Balls)
            {
               SpawnBalls(i.gameObject.transform.position);
            }
        }
    }
    public void TakeIncreaseSpeedOfBall(int _speedOfBall)
    {
        PowerBall += _speedOfBall;
        Debug.Log(PowerBall);
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
        Debug.Log(PowerBall);
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
    private void AddDifferentForceToBall()
    {
        float difference = _platformCentr - _positionOfHitBall;

        if (difference > 0 && difference < AppliedForce.RengthOfAppliedForce)
        {
            _rigidbodyOfBall.AddForce(new Vector2(-(Mathf.Abs(0.005f * PowerBall)), 0.055f * PowerBall));
        }
        if (difference > AppliedForce.RengthOfAppliedForce && difference < AppliedForce.RengthOfAppliedForce * 2)
        {
            _rigidbodyOfBall.AddForce(new Vector2(-Mathf.Abs(0.01f * PowerBall), 0.05f * PowerBall));
        }
        if (difference > AppliedForce.RengthOfAppliedForce * 2 && difference < AppliedForce.RengthOfAppliedForce * 3)
        {
            _rigidbodyOfBall.AddForce(new Vector2(-(Mathf.Abs(0.02f * PowerBall)), 0.04f * PowerBall));
        }
        if (difference > AppliedForce.RengthOfAppliedForce * 3 && difference < AppliedForce.RengthOfAppliedForce * 4)
        {
            _rigidbodyOfBall.AddForce(new Vector2(-(Mathf.Abs(0.03f * PowerBall)), 0.03f * PowerBall));
        }
        if (difference > AppliedForce.RengthOfAppliedForce * 4 && difference < AppliedForce.RengthOfAppliedForce * 5)
        {
            _rigidbodyOfBall.AddForce(new Vector2(-(Mathf.Abs(0.04f * PowerBall)), 0.02f * PowerBall));
        }
        if (difference > AppliedForce.RengthOfAppliedForce * 5 && difference < AppliedForce.RengthOfAppliedForce * 6)
        {
            _rigidbodyOfBall.AddForce(new Vector2(-(Mathf.Abs(0.05f * PowerBall)), 0.01f * PowerBall));
        }
        if (difference > AppliedForce.RengthOfAppliedForce * 6 && difference < AppliedForce.RengthOfAppliedForce * 7.1)
        {
            _rigidbodyOfBall.AddForce(new Vector2(-(Mathf.Abs(0.055f * PowerBall)), 0.005f * PowerBall));
        }
        //Reverse
        if (difference < 0 && difference > -AppliedForce.RengthOfAppliedForce)
        {
            _rigidbodyOfBall.AddForce(new Vector2(Mathf.Abs(0.005f * PowerBall), 0.055f * PowerBall));
        }
        if (difference < -AppliedForce.RengthOfAppliedForce && difference > -AppliedForce.RengthOfAppliedForce * 2)
        {
            _rigidbodyOfBall.AddForce(new Vector2(Mathf.Abs(0.01f * PowerBall), 0.05f * PowerBall));
        }
        if (difference < -AppliedForce.RengthOfAppliedForce * 2 && difference > -AppliedForce.RengthOfAppliedForce * 3)
        {
            _rigidbodyOfBall.AddForce(new Vector2(Mathf.Abs(0.02f * PowerBall), 0.04f * PowerBall));
        }
        if (difference < -AppliedForce.RengthOfAppliedForce * 3 && difference > -AppliedForce.RengthOfAppliedForce * 4)
        {
            _rigidbodyOfBall.AddForce(new Vector2(Mathf.Abs(0.03f * PowerBall), 0.03f * PowerBall));
        }
        if (difference < -AppliedForce.RengthOfAppliedForce * 4 && difference > -AppliedForce.RengthOfAppliedForce * 5)
        {
            _rigidbodyOfBall.AddForce(new Vector2(Mathf.Abs(0.04f * PowerBall), 0.02f * PowerBall));
        }
        if (difference < -AppliedForce.RengthOfAppliedForce * 5 && difference > -AppliedForce.RengthOfAppliedForce * 6)
        {
            _rigidbodyOfBall.AddForce(new Vector2(Mathf.Abs(0.05f * PowerBall), 0.01f * PowerBall));
        }
        if (difference < -AppliedForce.RengthOfAppliedForce * 6 && difference > -AppliedForce.RengthOfAppliedForce * 7.1)
        {
            _rigidbodyOfBall.AddForce(new Vector2(Mathf.Abs(0.055f * PowerBall), 0.005f * PowerBall));
        }
    }
    public void OnStickyPlatform(bool _switch)
    {
        if (_switch)
        {
            BallIsStuck = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D contact)
    {
        if(contact.gameObject.tag == "Player")
        {
            Vector3 hitPoint = contact.contacts[0].point;
            Vector3 platformCenter = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y);

            _positionOfHitBall = hitPoint.x;
            _platformCentr = platformCenter.x;
            _rigidbodyOfBall.velocity = Vector2.zero;

            AddDifferentForceToBall();
        }
    }
    private void Update()
    {
        CheckMaxOrMinSpeedOfBall();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (BallIsActive == false)
            {
                BallIsActive = true;
                _rigidbodyOfBall.AddForce(new Vector2(Mathf.Abs(0.005f * PowerBall), 0.055f * PowerBall));
                _rigidbodyOfBall.freezeRotation = true;
            }
            if (BallIsStuck == true)
            {
                BallIsStuck = false;
                AddDifferentForceToBall();
                _rigidbodyOfBall.freezeRotation = true;
            }
        }
        if (BallIsActive == false)
        {
            _rigidbodyOfBall.velocity = new Vector2(0, 0);
            _ballPosition.x = playerObject.transform.position.x;
            transform.position = _ballPosition;
        }
        if (BallIsStuck == true)
        {
            _rigidbodyOfBall.velocity = new Vector2(0, 0);
            _ballPosition.x = playerObject.transform.position.x + (_positionOfHitBall - _platformCentr);
            _ballPosition.y = 82;
            transform.position = _ballPosition;
        }
        if (transform.position.y < -15f)
        {
            Balls = GameObject.FindGameObjectsWithTag("Ball");
            if (Balls.Length == 1)
            {
                GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
                player.gameObject.GetComponent<Player>().TakeAwayHealth(_healthThatIsLose);
                BallIsActive = false;
                _ballPosition.x = playerObject.transform.position.x;
                _ballPosition.y = 82f;
                transform.position = _ballPosition;
            }
        }
        if(transform.position.y < -25f)
        {
            Destroy(this.gameObject);
        }
    }
}
