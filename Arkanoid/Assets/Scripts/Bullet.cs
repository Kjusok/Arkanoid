using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _ridgidBodyOfBullet;
    void Start()
    {
        _ridgidBodyOfBullet.AddForce(new Vector2(0, 7));
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Block" || collider.gameObject.tag == "Top Wall")
        {
            Destroy(this.gameObject);
        }
    }
}