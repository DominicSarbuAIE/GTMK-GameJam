using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Lion : Player
{
    void Start()
    {
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

    public void DoDamage(int _damage)
    {
        Debug.Log("Hit");
        _rb.AddForce(transform.forward * _knockback);
        _health -= _damage;
        _playerHealthBar.ChangeHealthBar(_health);
    }
}
