using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    //public Camp _camp;
    //[SerializeField] private Transform _campsPos;
    //[SerializeField] private Transform _enemyPos;
    public bool _enemyInCamp = false;
    public Enemy _enemy;
    protected float _distance;
    [SerializeField] private float _rotationSpeed;

    public Transform _player;

    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
        _rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //_distance = Vector3.Distance(_campsPos.position, transform.position);
        Vector3 _dir = _player.position - transform.position;
        _rb.rotation = Quaternion.LookRotation(_dir);

        if (_distance <= 6)
        {
            _enemyInCamp = true;
        }
    }

    public void StopEnemy()
    {
        _enemy._speed = 0;
    }

    public void GoToPlayer()
    {
        _enemy._speed = 2;
        transform.position = Vector3.MoveTowards(transform.position, _enemy._playerTransform.position, _enemy._speed * Time.deltaTime);
    }

    //public void MoveToCamp()
    //{
    //    Vector3 enemyPos = new Vector3(_enemyPos.position.x, transform.position.y, _enemyPos.position.z);
    //    Vector3 _campPosition = new Vector3(_campsPos.position.x, transform.position.y, _campsPos.position.z);
    //
    //    if(_distance > 6)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, _campsPos.position, _enemy._speed * Time.deltaTime);
    //    }
    //}
}
