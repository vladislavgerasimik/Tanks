using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    [SerializeField] private bool _wasd;
    [Header("Tank:")]
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [Header("Weapon:")]
    [SerializeField] private float _reloadTime;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Image _timer;
    private Rigidbody2D _rigidbody2D;
    private bool _canShoot;
    private float _elapsedTime;
   
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    
    void Update()
    {
        if(_wasd == true)
        {
            Move(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D);
            Shoot(KeyCode.Space);
        }
        else
        {
            Move(KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow);
            Shoot(KeyCode.Return);
        }

        CanShoot();
    }

    private void Move(KeyCode Up, KeyCode Down, KeyCode Left, KeyCode Right)
    {

        float velocity = 0;
        if (Input.GetKey(Up) || Input.GetKey(Down))
        {
            if (Input.GetKey(Up))
            {
                velocity = 1;
            }
            else
            {
                velocity = -1;
            }
            _rigidbody2D.AddForce(transform.right * velocity * _speed, ForceMode2D.Impulse);
        }
        float h = 0;
        if (Input.GetKey(Right) || Input.GetKey(Left))
        {
            if (Input.GetKey(Left))
            {
                h = 1;
            }
            else
            {
                h = -1;
            }
            _rigidbody2D.AddTorque(_rotationSpeed * h, ForceMode2D.Impulse);
        }
    }


    private void Shoot(KeyCode ShootButton)
    {
        if(Input.GetKey(ShootButton) && _canShoot == true)
        {
            _canShoot = false;
            Bullet bullet = Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
            bullet.transform.Rotate(transform.rotation.eulerAngles, Space.World);
            bullet.SetDirection(_shootPoint.right);
        }
    }

    private void CanShoot()
    {
        if(_canShoot == true)
        {
            return;
        }
        _elapsedTime += Time.deltaTime;
        _timer.fillAmount = _elapsedTime / _reloadTime;
        if(_elapsedTime >= _reloadTime)
        {
            _elapsedTime = 0;
            _canShoot = true;
        }
    }
}





//Найти спрайт для таймера и добавить их игру
//Добавить разрушаемые стены
