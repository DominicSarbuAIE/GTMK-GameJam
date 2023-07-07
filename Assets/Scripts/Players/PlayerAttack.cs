using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _rangeOfAttack;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private KnifeGuy _knifeGuy;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] _hitEnemys = Physics.OverlapSphere(_attackPoint.position, _rangeOfAttack, _enemyLayers);

        foreach(Collider enemys in _hitEnemys)
        {
            Debug.Log("we hit enemy");
            enemys.GetComponent<KnifeGuy>().TakeDamage(_damage);
        }
    }
}
