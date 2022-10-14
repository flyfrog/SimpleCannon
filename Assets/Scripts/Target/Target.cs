using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Target : MonoBehaviour  
{
    [SerializeField] private int _health;
    [SerializeField] private TextMeshPro _texthealth;
    
    private HitController _hitController;

    private void Awake()
    {
        _hitController = FindObjectOfType<HitController>(); //  грязный хак который нельзя в прод
        
        RegisterInTargetCountController();
    }

    private void RegisterInTargetCountController()
    {
        FindObjectOfType<TargetCountController>().RegistrationTarget(gameObject.GetComponent<Target>()); // тоже отрефакторить 
    }

    private void Start()
    {
        DrawHealthValue();
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        _hitController.TargetHit(gameObject.GetComponent<Target>());
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _health =  Math.Clamp(_health,0, int.MaxValue);
        DrawHealthValue();
    }
    
    public int GetHealth()
    {
        return _health;
    }

    private void DrawHealthValue()
    {
        _texthealth.text =  _health.ToString();
    }
    
}