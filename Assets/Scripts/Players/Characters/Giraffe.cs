using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Giraffe : Player
{
    void Start()
    {
        _maxHealth = 9;
        _speed = 6;
        _damage = 2;
        _knockBack = 650;

        base.Start();
    }

    void Update()
    {
        base.Update();
    }

    void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
