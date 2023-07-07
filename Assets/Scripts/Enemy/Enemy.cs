using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Stats
    protected float _health;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _attackDamage;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected float _maxHealth;

    // Other
    protected Transform _player;

    // Start is called before the first frame update
    protected void Start()
    {
        // identify player object using Player tag
        _player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    protected void Update()
    {
        // Get player position
        Vector3 targetpos = new Vector3(_player.position.x, transform.position.y, _player.position.z);
        // Move Towards "targetpos" (Player)
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
    }
}
