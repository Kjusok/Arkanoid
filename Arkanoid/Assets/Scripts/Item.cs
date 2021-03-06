using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject[] _createHearts;
    [SerializeField] private int _points;
    [SerializeField] private int _size;
    [SerializeField] private int _speedOfBall;
    [SerializeField] private int _time;
    [SerializeField] private bool _switch;

    private int _healthThatIsTaken = 1;
    private Vector2 _positionOfItem;

    void Start()
    {
        _positionOfItem = transform.position;
    }
    void Update()
    {
        if (transform.position.y < -20f)
        {
            Destroy(this.gameObject);
        }
    }
    public void CreateHealth()
    {
        if (Player.Health.Length == 4 && Player.HealthOfPlayer == 5)
        {
            _positionOfItem = new Vector3(1593.5f, 1026.2f, 10);
            Instantiate(_createHearts[0], _positionOfItem, Quaternion.identity);
        }
        if (Player.Health.Length == 3 && Player.HealthOfPlayer == 4)
        {
            _positionOfItem = new Vector3(1653.5f, 1026.2f, 10);
            Instantiate(_createHearts[0], _positionOfItem, Quaternion.identity);
        }
        if (Player.Health.Length == 2 && Player.HealthOfPlayer == 3)
        {
            _positionOfItem = new Vector3(1713.5f, 1026.2f, 10);
            Instantiate(_createHearts[0], _positionOfItem, Quaternion.identity);
        }
        if (Player.Health.Length == 1 && Player.HealthOfPlayer == 2)
        {
            _positionOfItem = new Vector3(1773.5f, 1026.2f, 10);
            Instantiate(_createHearts[0], _positionOfItem, Quaternion.identity);
        }
    }
    public void TakeLive()
    {
        if (this.gameObject.tag == "Live")
        {
            Destroy(this.gameObject);

            Player.Health = GameObject.FindGameObjectsWithTag("Health Player");

            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.gameObject.GetComponent<Player>().HealthUp(_healthThatIsTaken);

            if (Player.HealthOfPlayer == 5)
            {
                player.gameObject.GetComponent<Player>().AddPoints(_points);
            }
            if (Player.Health.Length < 5)
            {
                CreateHealth();
            }
        }
    }
    private void TakePlatformResizing()
    {
        if (this.gameObject.tag == "Plus" || this.gameObject.tag == "Minus")
        {
            Destroy(this.gameObject);

            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.gameObject.GetComponent<Platform>().TakeChangePlatformSize(_size);
        }
    }
    private void TakeChangeBallSpeed()
    {
        if (this.gameObject.tag == "SpeedUp")
        {
            Destroy(this.gameObject);

            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach(GameObject ball in balls)
            {
                ball.gameObject.GetComponent<Ball>().TakeIncreaseSpeedOfBall(_speedOfBall);
            }
        }
        if (this.gameObject.tag == "SpeedDown")
        {
            Destroy(this.gameObject);

            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in balls)
            {
                ball.gameObject.GetComponent<Ball>().TakeDecreaseSpeedOfBall(_speedOfBall);
            }
        }
    }
    private void TakeShieldFloorForTime()
    {
        if (this.gameObject.tag == "Shield")
        {
            Destroy(this.gameObject);

            GameObject fieldOfGame = GameObject.FindGameObjectsWithTag("Game")[0];
            fieldOfGame.gameObject.GetComponent<FieldOfGame>().TakeTimeForShieldFloor(_time);
        }
    }
    private void TakeVelcroForPlatform()
    {
        if (this.gameObject.tag == "Velcro")
        {
            Destroy(this.gameObject);

            GameObject platform = GameObject.FindGameObjectsWithTag("Player")[0];
            platform.gameObject.GetComponent<Platform>().TakeTimeForStickyPlatform(_time);
        }
    }
    private void TakeGuns()
    {
        if (this.gameObject.tag == "Guns")
        {
            Destroy(this.gameObject);
            GameObject platform = GameObject.FindGameObjectsWithTag("Player")[0];
            platform.gameObject.GetComponent<Platform>().TakeTimeForGuns(_time);
        }
    }
    private void TakeDublication()
    {
        if (this.gameObject.tag == "Duplication")
        {
            Destroy(this.gameObject);
            GameObject platform = GameObject.FindGameObjectsWithTag("Ball")[0];
            platform.gameObject.GetComponent<Ball>().TakeMultyBall(_switch);
        }
    }
    private void TakeSuperBall()
    {
        if (this.gameObject.tag == "Super Ball")
        {
            Destroy(this.gameObject);
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in balls)
            {
                ball.gameObject.GetComponent<Ball>().TakeTimeForSuperBall(_time);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            TakeLive();
            TakePlatformResizing();
            TakeChangeBallSpeed();
            TakeShieldFloorForTime();
            TakeVelcroForPlatform();
            TakeGuns();
            TakeDublication();
            TakeSuperBall();
        }
    }
}



