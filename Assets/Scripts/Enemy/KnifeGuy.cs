using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KnifeGuy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        _distance = Vector3.Distance(_player.position, transform.position);

        if (_distance < _minRange)
        {
            StopEnemy();
        }
        else if (_distance > _maxRange)
        {
            StopEnemy();
        }
        else
        {
            // Move Towards "targetpos" (Player)
            GoToPlayer();
        }
    }

    private void StopEnemy()
    {
        _speed = 0;
    }

    private void GoToPlayer()
    {
        _speed = 2;
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
    }
}
