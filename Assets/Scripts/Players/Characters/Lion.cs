using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Lion : Player
{
    void Start()
    {
        _maxHealth = 8;
        _speed = 7;
        _damage = 1;
        _knockBack = 500;

        base.Start();
    }

    void Update()
    {
        base.Update();
        if(_health <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    void FixedUpdate()
    {
        base.FixedUpdate();
    }

    //public void DoDamage(int _damage)
    //{
    //    Debug.Log("Hit");
    //    _rb.AddForce(transform.forward * _knockback);
    //    _health -= _damage;
    //    _playerHealthBar.ChangeHealthBar(_damage);
    //}


}
