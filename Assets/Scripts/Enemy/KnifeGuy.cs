using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KnifeGuy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        ChaseSpeed = 4;
        ReturnSpeed = 2;
        IdleSpeed = 1;
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
    }
}
