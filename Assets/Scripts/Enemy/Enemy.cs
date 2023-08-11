using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Stats
    private float _health;
    private float _maxHealth;    
    public float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }
    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    private float _maxRange;
    public float MaxRange
    {
        get { return _maxRange; }
        set { _maxRange = value; }
    }
    private float _minRange;
    public float MinRange
    {
        get { return _minRange; }
        set { _minRange = value; }
    }
    private int _attackDamage;
    public int AttackDamage
    {
        get { return _attackDamage; }
        set { _attackDamage = value; }
    }

    public Transform _player;
    //public bool _isAttacking = false;
    protected float _distance;
    //[SerializeField] private bool _canAttack = true;
    public Transform _playerTransform;
    private Rigidbody _rigidbody;
    [SerializeField] private float _force;

    // Start is called before the first frame update
    protected void Start()
    {
        // identify player object using Player tag
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _health = _maxHealth;
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected void Update()
    {
        // Get player position
        //Vector3 targetpos = new Vector3(_player.position.x, transform.position.y, _player.position.z);
        _distance = Vector3.Distance(_playerTransform.position, transform.position);

        //MeleeCanAttack();

        if (_health <= 0)
        {
            StartCoroutine(OnDeath());
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void GoToPlayer()
    {
        _speed = Speed;
        transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
    }

    public void StopEnemy()
    {
        _speed = 0;
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