using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Stats
    public float _health;
    [SerializeField] public float _speed;
    [SerializeField] protected float _attackDamage;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _maxRange;
    [SerializeField] protected float _minRange;
    [SerializeField] protected float _maxHealth;
    [SerializeField] private LayerMask _playerLayMask;
    protected float _distance;

    // Other
    public Transform _player;

    // Start is called before the first frame update
    protected void Start()
    {
        // identify player object using Player tag
        _player = GameObject.FindWithTag("Player").transform;
        _health = _maxHealth;
    }

    // Update is called once per frame
    protected void Update()
    {
        // Get player position
        //Vector3 targetpos = new Vector3(_player.position.x, transform.position.y, _player.position.z);

        if (_health <= 0)
        {
            StartCoroutine(OnDeath());
        }

    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        Debug.Log(_health);
    }

    private IEnumerator OnDeath()
    {

        yield return new WaitForSeconds(0.0000001f);
        Debug.Log("dead");

        Destroy(gameObject);
    }
}
