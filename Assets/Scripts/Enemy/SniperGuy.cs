using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SniperGuy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Speed = 2;
        MinRange = 10;
        MaxRange = 20;
        MaxHealth = 3;
        AttackDamage = 1;

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
