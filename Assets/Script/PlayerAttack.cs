using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    float _timeBetweenAttacks = 5f;

    float _timeToNextAttack = 100000000;

    [SerializeField] private Animator _animator;

    private void Update()
    {

        _timeToNextAttack -= Time.deltaTime;

        if (_timeToNextAttack <= 0) Attack();
    }



    private void Attack()
    {

        _animator.SetTrigger("Attack");
        var colliders = Physics.BoxCastAll(transform.position + transform.right, Vector3.zero, transform.right, Quaternion.identity, 1f);

        Debug.Log("Attack");
        foreach (var item in colliders)
        {
            item.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage();
        }

        _timeToNextAttack = _timeBetweenAttacks;
    }
}
