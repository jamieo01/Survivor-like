using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamageable
{
    Rigidbody _myRigidbody;
    float _horizontal;
    float _vertical;
    [SerializeField] float _speed = 10;

    private int _maxHealth = 5;

    private int _currentHealth =5;

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
    }
   

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null) TakeDamage();
    }

    public void TakeDamage()
    {
        Debug.Log("TakeDamage");
    }
}
