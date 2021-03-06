using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blocks : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteOfBlock;
    [SerializeField] private int _healthOfBlock;
    [SerializeField] private int _points;
    [SerializeField] private GameObject[] _items;

    private Vector2 _positionOfItems;

    void Start()
    {
        _spriteOfBlock = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (_healthOfBlock == 1)
        {
            Color newColor = new Color(1, 1, 1);
            _spriteOfBlock.color = newColor;
        }
        if (_healthOfBlock == 2)
        {
            Color newColor = new Color(0.97f, 1, 0);
            _spriteOfBlock.color = newColor;
        }
        if (_healthOfBlock == 3)
        {
            Color newColor = new Color(1, 0.5f, 0);
            _spriteOfBlock.color = newColor;
        }
    }
    private void DesttroyBlockAndCreateItems()
    {
        _healthOfBlock--;

        if (_healthOfBlock == 0)
        {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.gameObject.GetComponent<Player>().AddPoints(_points);
            _positionOfItems = this.gameObject.transform.position;
            Destroy(this.gameObject);

            if (Random.Range(0, 100) < 20)
            {
                Instantiate(_items[Random.Range(0, 10)], _positionOfItems, Quaternion.identity);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            DesttroyBlockAndCreateItems();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            DesttroyBlockAndCreateItems();
        }
        if (collider.gameObject.tag == "Ball")
        {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.gameObject.GetComponent<Player>().AddPoints(_points);
            _positionOfItems = this.gameObject.transform.position;
            Destroy(this.gameObject);

            if (Random.Range(0, 100) < 20)
            {
                Instantiate(_items[Random.Range(0, 10)], _positionOfItems, Quaternion.identity);
            }
        }
    }
}