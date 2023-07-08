using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeMelee : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDelay;
    [SerializeField] private bool _canAttack = false;
    [SerializeField] private Rigidbody _player;
    private float _distance;
    [SerializeField] private KnifeGuy _speed;
    public bool _isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(_player.position, transform.position);

        if (_distance < 1)
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
        _canAttack = false;
        _speed._speed = 0;
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        _isAttacking = false;
        yield return new WaitForSeconds(_attackDelay);
        _speed._speed = 2;
        _canAttack = true;
    }
}
