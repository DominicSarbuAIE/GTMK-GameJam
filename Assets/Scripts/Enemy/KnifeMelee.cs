using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeMelee : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDelay;
    [SerializeField] private bool _canAttack = true;
    [SerializeField] private Rigidbody _player;
    [SerializeField] private float _distance;
    [SerializeField] private KnifeGuy _speed;
    public bool _isAttacking = false;
    public int _damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(_player.position, transform.position);

        if (_distance < 2)
        {
            if (_canAttack)
            {
                Attack();
            }
        }
    }

    public void Attack()
    {
        _isAttacking = true;
        _speed._speed = 0;
        StartCoroutine(AttackCooldown());
        _canAttack = false;
    }
    
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(_attackDelay);
        _isAttacking = false;
        _speed._speed = 2;
        _canAttack = true;
    }
}
