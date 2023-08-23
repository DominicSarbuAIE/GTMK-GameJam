using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Hippo : Player
{
    void Start()
    {
        _maxHealth = 10;
        _speed = 7;
        _damage = 2;
        _knockBack = 800;

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
