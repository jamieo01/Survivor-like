using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerStatistics _playerStatistics;
    private float _timeBetweenAttacks = 5f;

    private float _timeToNextAttack = 5;

    private bool _rightAttack = true;
    private bool _leftAttack = false;
    private bool _upAttack = false;
    private bool _downAttack = false;

    [SerializeField] private LineRenderer _rightAttackLine;
    [SerializeField] private LineRenderer _leftAttackLine;
    [SerializeField] private LineRenderer _upAttackLine;
    [SerializeField] private LineRenderer _downAttackLine;

    private void Awake()
    {
        _playerStatistics = GetComponent<PlayerStatistics>();
    }

    private void Update()
    {

        _timeToNextAttack -= Time.deltaTime;
      
        if (_timeToNextAttack <= 0) Attack();
     
    }



    private void Attack()
    {

        if (_rightAttack)
        {
            var colliders =FindEnemiesLocation(transform.right);
            foreach (var item in colliders)
            {
                IDamageable damageable = item.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage();
                    item.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10, ForceMode.Impulse);
                }
            }
            
            StartCoroutine( AttackLine(_rightAttackLine, transform.right * _playerStatistics.AttackRange));
           
        }
        if (_leftAttack)
        {
            var colliders = FindEnemiesLocation(-transform.right);
            foreach (var item in colliders)
            {
                IDamageable damageable = item.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage();
                    item.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10, ForceMode.Impulse);
                }
            }
            StartCoroutine(AttackLine(_leftAttackLine, -transform.right * _playerStatistics.AttackRange));
        }
        if (_upAttack)
        {
            var colliders = FindEnemiesLocation(transform.forward);
            foreach (var item in colliders)
            {
                IDamageable damageable = item.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage();
                    item.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10, ForceMode.Impulse);
                }
            }
            StartCoroutine(AttackLine(_upAttackLine, transform.forward * _playerStatistics.AttackRange));
        }
        if (_downAttack)
        {
            var colliders = FindEnemiesLocation(-transform.forward);
            foreach (var item in colliders)
            {
                IDamageable damageable = item.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage();
                    item.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10, ForceMode.Impulse);
                }
            }
            StartCoroutine(AttackLine(_downAttackLine, -transform.forward * _playerStatistics.AttackRange));
        }
        _timeToNextAttack = _timeBetweenAttacks;
    }

    private RaycastHit[] FindEnemiesLocation(Vector3 attackDirection) { return Physics.BoxCastAll(transform.position + attackDirection, Vector3.zero, attackDirection, Quaternion.identity, 2f); }

    private IEnumerator AttackLine(LineRenderer lineRender, Vector3 attackDirecton ) 
    {
        lineRender.SetPosition(1, attackDirecton);
        yield return new WaitForSeconds(.2f);
        lineRender.SetPosition(1, Vector3.zero);
    }
}
