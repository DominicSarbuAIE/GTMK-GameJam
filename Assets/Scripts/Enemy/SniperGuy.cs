using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SniperGuy : Enemy
{

    public EnemyMovement _movement;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        _distance = Vector3.Distance(_playerTransform.position, transform.position);

        if (_distance < _minRange)
        {
            _movement.StopEnemy();
        }
        else if(_distance > _maxRange)
        {
            _movement._enemyInCamp = false;
            //_movement.MoveToCamp();
        }
        else
        {
            // Move Towards "targetpos" (Player)
            _movement.GoToPlayer();
        }
    }

}
