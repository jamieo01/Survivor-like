using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{

    private int _maxHealth =100;
    [SerializeField] private float _attackSpeed = 5;

    private float _attackRange = 1.5f;
    public float AttackSpeed { get => _attackSpeed;}
    public float AttackRange { get => _attackRange;}
    public int MaxHealth { get => _maxHealth; }

    private void Awake()
    {
        References.PlayerStatistics = this;
    }
}
