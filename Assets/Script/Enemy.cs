using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    [SerializeField] private float _moveSpeed = 0;
    private Rigidbody _rigidbody;
    private float _health = 10;
    [SerializeField]Player _player;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void TakeDamage( )
    {
        
        GetComponent<Rigidbody>().AddForce(Vector3.right * 10, ForceMode.Impulse);
        --_health;
        if (_health <= 0) DestroyImmediate(this);
        

        
    }

    private void Update()
    {
        _rigidbody.MovePosition(Vector3.MoveTowards(_rigidbody.position, _player.transform.position,Time.deltaTime * _moveSpeed));
        transform.forward = transform.position -( _player.transform.position - Vector3.down*-.5f );
    }

}
