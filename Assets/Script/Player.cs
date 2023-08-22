using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour,IDamageable
{
    private void Awake()
    {
        References.Player = this;
    }

    [SerializeField] private GameObject _grapics;
    private Rigidbody _myRigidbody;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _speed = 10;

    private int _currentCash;
    [SerializeField] private TextMeshProUGUI _cashText;

    private float _currentExperience= 0;
    private float _experienceToLevelUp = 100;
    private int _currentLevel = 1;
    private int _skillPoint = 0;
    
    private List<PlayerAbility> _playerAbilities = new List<PlayerAbility>();

    [SerializeField] private Image _healthbarImage;
    private int _currentHealth = 100;
    private float _invinciblePeriod = .2f;
    private float _currentInvincibleamount;

   
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
        _currentHealth = References.PlayerStatistics.MaxHealth;
        _cashText.SetText($"Cash: {_currentCash}");
    }

    void Update()
    {
        if (_currentHealth > 0)
        {
            _horizontal = Input.GetAxisRaw("Horizontal");
            _vertical = Input.GetAxisRaw("Vertical");

            Vector3 directionToMove = new Vector3( _horizontal, 0, _vertical );

            _myRigidbody.MovePosition(transform.position + directionToMove * _speed * Time.deltaTime) ;


            _grapics.transform.forward = directionToMove ;            
            _currentInvincibleamount -= Time.deltaTime;
        }
    }

    internal void AddCash(int cashValue)
    {
        _currentCash = cashValue;
        _cashText.SetText($"Cash: {_currentCash}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null) TakeDamage();
    }

    public void AddExperience(float experienceToAdd) 
    {
        if (_currentExperience + experienceToAdd > _experienceToLevelUp)
        {
            float spareExperience = experienceToAdd - ( _experienceToLevelUp - _currentExperience);
            _currentExperience = 0;
            LevelUp();
            _currentExperience += spareExperience;

        }
    
    }

    private void LevelUp() 
    {
        Debug.Log("Level UP");
        _currentLevel++;
    }

    public void TakeDamage()
    {
        if (_currentInvincibleamount <= 0) 
        {
            _currentHealth--;
            _healthbarImage.fillAmount =   _currentHealth * 1f/100 ;
            _currentInvincibleamount = _invinciblePeriod;
        }
    }
}
