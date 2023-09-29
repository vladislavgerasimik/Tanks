using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private int _speed;

    public void SetDirection(Vector3 direction)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = direction.normalized * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
