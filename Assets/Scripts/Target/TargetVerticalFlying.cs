using System;
using UnityEngine;
using Zenject;


[RequireComponent(typeof(Rigidbody2D))]
public class TargetVerticalFlying : MonoBehaviour
{
    [SerializeField] private float _movingForce;
    [SerializeField] private float _timeChangeFlyDirection;
    private float _currentTime;
    private float _direction = 1;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PingPongDirection();
    }

    private void MovingTarget()
    {
        _rigidbody.AddForce(Vector2.up * _direction * _movingForce, ForceMode2D.Impulse);
    }

    private void PingPongDirection()
    {
        if (_currentTime < _timeChangeFlyDirection)
        {
            _currentTime += Time.deltaTime;
        }
        else
        {
            _currentTime = 0;
            _direction *= -1;
            MovingTarget();
        }
    }
}