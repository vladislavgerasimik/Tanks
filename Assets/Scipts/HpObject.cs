using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpObject : MonoBehaviour
{
    [SerializeField] private int _MaxHp;
    private int _currentHp;
    public int MaxHp => _MaxHp;
    public int CurrentHp => _currentHp;

    private void Start()
    {
        _currentHp = _MaxHp;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
            _currentHp = _currentHp - 10;
            if (_currentHp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

//Добавить HP Bar на каждую сцену