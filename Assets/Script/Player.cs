using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour,IDamageable
{
    private Rigidbody _myRigidbody;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _speed = 10;
    [SerializeField] private TextMeshProUGUI _healthGrapics;

    private int _maxHealth = 5;


    private int _currentHealth = 100;
    private float _invinciblePeriod = .2f;
    private float _currentInvincibleamount;

    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        _myRigidbody.MovePosition(transform.position + Vector3.right * _horizontal * _speed* Time.deltaTime
            + Vector3.forward * _vertical *_speed * Time.deltaTime );

        _currentInvincibleamount -= Time.deltaTime;
    }
   

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null) TakeDamage();
    }

    public void TakeDamage()
    {
        if (_currentInvincibleamount <= 0) 
        {
            _currentHealth--;
            _currentInvincibleamount = _invinciblePeriod;
        }
    }
}
