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
        base.Start();
    }

    void Update()
    {
        base.Update();
        if(_health <= 0)
        {
            SceneManager.LoadScene(2);
        }
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
        _playerHealthBar.ChangeHealthBar(_damage);
    }


}
