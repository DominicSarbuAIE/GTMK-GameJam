using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Stats
    // Updating Stats
    protected float _health; // Current health
    protected float _currentSpeed; // current speed type e.g. _chaseSpeed | _returnSpeed | _idleSpeed

    // Stats pulled from enemy type e.g. Knifeguy | SpearGuy | SniperGuy
    public float MaxHealth { get; protected set;  }// Max health
    public float MaxRange { get; protected set; } // Max Detection Range
    public float MinRange { get; protected set; } // ~~~~
    public int AttackDamage { get; protected set; } // Attack Damage

    // Speed types
    public float ChaseSpeed { get; protected set; } // Speed when chasing player
    public float ReturnSpeed { get; protected set; } // Speed when returning to camp
    public float IdleSpeed { get; protected set; } // Speed when idle/wandering in camp

    public Transform _player;
    protected float _distance;
    public Transform _playerTransform;
    private Rigidbody _rigidbody;
    [SerializeField] private float _force;

    // Combat?
    //public bool _isAttacking = false;
    //[SerializeField] private bool _canAttack = true;

    GameObject jitter;
    Vector3 wanderTarget = Vector3.zero;
    NavMeshAgent agent;

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
        _distance = Vector3.Distance(_playerTransform.position, transform.position);

        //MeleeCanAttack();

        if (_health <= 0)
        {
            StartCoroutine(OnDeath());
        }

        if (_distance < MinRange || _distance > MaxRange)
        {
            //StopEnemy();
            Wander();
        }
        else
        {
            GoToPlayer();
        }
    }

    // Movement Functions
    public void GoToPlayer()
    {
        _currentSpeed = ChaseSpeed;
        transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, _currentSpeed * Time.deltaTime);
    }

    public void StopEnemy()
    {
        _currentSpeed = 0;
    }

    void Seek(Vector3 location)
    {

        agent.SetDestination(location);
    }

    public void Wander()
    {

        float wanderRadius = 10.0f;
        float wanderDistance = 20.0f;
        float wanderJitter = 1.0f;

        wanderTarget += new Vector3(
            Random.Range(-1.0f, 1.0f) * wanderJitter,
            0.0f,
            Random.Range(-1.0f, 1.0f));
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0.0f, 0.0f, wanderDistance);
        Vector3 targetWorld = gameObject.transform.InverseTransformVector(targetLocal);

        Debug.DrawLine(transform.position, targetWorld, Color.red);
        jitter.transform.position = targetWorld;
        Seek(targetWorld);
    }

    public void Return()
    {

    }

    public void TakeDamage(float damage)
    {
        _rigidbody.AddForce(transform.forward * _force);
        _health -= damage;
    }

    private IEnumerator OnDeath()
    {

        yield return new WaitForSeconds(0.0000001f);
        Debug.Log("dead");

        Destroy(gameObject);
    }

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