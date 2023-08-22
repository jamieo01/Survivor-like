using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IDamageable
{

    [SerializeField]private int _maxHealth;
    

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage()
    {
        _currentHealth -= _maxHealth;

    }
}
