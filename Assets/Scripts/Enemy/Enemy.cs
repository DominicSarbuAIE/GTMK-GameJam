using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Stats
    public float _health;
    [SerializeField] public float _speed;
    [SerializeField] protected float _maxRange;
    [SerializeField] protected float _minRange;
    [SerializeField] protected float _maxHealth;
    [SerializeField] private LayerMask _playerLayMask;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDelay;
    public int _attackDamage;

    // Other
    Lion _player;
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
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Lion>();
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
