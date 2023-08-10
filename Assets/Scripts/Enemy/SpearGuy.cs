using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SpearGuy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Speed = 3;
        MinRange = 5;
        MaxRange = 14;
        MaxHealth = 4;
        AttackDamage = 2;

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
