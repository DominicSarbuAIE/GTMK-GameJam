using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Stats
    protected float _health; // Current health
    public float MaxHealth { get; protected set;  }// Max health
    protected float _currentSpeed; // current speed type e.g. _chaseSpeed | _returnSpeed | _idleSpeed
    public float MaxRange { get; protected set; } // Max Detection Range
    public float MinRange { get; protected set; } // ~~~~
    public int AttackDamage { get; protected set; } // Attack Damage

    // Speed types
    public float ChaseSpeed { get; protected set; }
    public float ReturnSpeed { get; protected set; }
    public float IdleSpeed { get; protected set; }


    public Transform _player;
    //public bool _isAttacking = false;
    protected float _distance;
    //[SerializeField] private bool _canAttack = true;
    public Transform _playerTransform;
    private Rigidbody _rigidbody;
    [SerializeField] private float _force;

    // Start is called before the first frame update
    public void Start()
    {
        // identify player object using Player tag
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _health = MaxHealth;
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        // Get player position
        //Vector3 targetpos = new Vector3(_player.position.x, transform.position.y, _player.position.z);
        _distance = Vector3.Distance(_playerTransform.position, transform.position);

        //MeleeCanAttack();

        if (_health <= 0)
        {
            StartCoroutine(OnDeath());
        }

        if (_distance < MinRange || _distance > MaxRange)
        {
            StopEnemy();
        }
        else
        {
            GoToPlayer();
        }
    }

    //private void FixedUpdate()
    //{
    //    if (_playerInRange && _distance > MinRange && _distance < MaxRange)
    //    {
    //        GoToPlayer();
    //    }
    //}

    public void GoToPlayer()
    {
        _currentSpeed = ChaseSpeed;
        transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, _currentSpeed * Time.deltaTime);
    }

    public void StopEnemy()
    {
        _currentSpeed = 0;
    }

    public void TakeDamage(float damage)
    {
        _rigidbody.AddForce(transform.forward * _force);
        _health -= damage;
        Debug.Log(_health);
    }

    private IEnumerator OnDeath()
    {

        yield return new WaitForSeconds(0.0000001f);
        Debug.Log("dead");

        Destroy(gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Hit");
    //
    //        _player.DoDamage(_attackDamage);
    //
    //    }
    //}

    //private void MeleeCanAttack()
    //{
    //    if (_distance < 2)
    //    {
    //        if (_canAttack)
    //        {
    //            Attack();
    //        }
    //    }
    //}
    //private void Attack()
    //{
    //    _isAttacking = true;
    //    _speed = 0;
    //    StartCoroutine(AttackCooldown());
    //    _canAttack = false;
    //}
    //
    //IEnumerator AttackCooldown()
    //{
    //    yield return new WaitForSeconds(_attackDelay);
    //    _isAttacking = false;
    //    _speed = 2;
    //    _canAttack = true;
    //}
}