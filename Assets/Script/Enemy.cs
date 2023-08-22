using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    [SerializeField] private float _moveSpeed = 0;
    private Rigidbody _rigidbody;
    private float _health = 1;

    [SerializeReference]private float _experienceValue;
    [SerializeReference] private int _cashValue;

    Player _player;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = References.Player;
    }
    public void TakeDamage( )
    {
        --_health;
        if (_health <= 0) Die();
    }

    private void Update()
    {
        _rigidbody.MovePosition(Vector3.MoveTowards(_rigidbody.position, _player.transform.position,Time.deltaTime * _moveSpeed));
        transform.forward = transform.position -( _player.transform.position - Vector3.down*-.5f );
    }

    private void Die() 
    {
        _player.AddExperience(_experienceValue);
        _player.AddCash(_cashValue);

        Destroy(this.gameObject);
    }
    private void OnCollisionStay(Collision collision)
    {
        IDamageable damageObject = collision.gameObject.GetComponent<IDamageable>();
        if (damageObject != null)
        {
            damageObject.TakeDamage();
        }
    }

}
