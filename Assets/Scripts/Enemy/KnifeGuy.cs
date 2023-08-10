using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KnifeGuy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Speed = 4;
        MinRange = 1;
        MaxRange = 14;
        MaxHealth = 4;
        AttackDamage = 1;

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (_distance < MinRange)
        {
            StopEnemy();
        }
        if (_distance > MaxRange)
        {
            StopEnemy();
        }
        else GoToPlayer();

    }


}
