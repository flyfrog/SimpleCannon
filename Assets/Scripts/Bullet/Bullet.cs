using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage; 
    private HitController _hitController;


    private void Start()
    {
        _hitController = FindObjectOfType<HitController>(); //  todo отрефакторить на фабрику
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        _hitController.BulletHit(gameObject.GetComponent<Bullet>(), col.gameObject);
    }

    public int GetDamage()
    {
        return _damage;
    }
}