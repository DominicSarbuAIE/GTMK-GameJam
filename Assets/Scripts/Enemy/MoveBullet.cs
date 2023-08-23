using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    [SerializeField] private float _force;
    private GameObject _player;
    private GameObject _bullet;
    private Rigidbody _bulletRigidbody;
    private float _timer;
    Lion _playerHealth;
    [SerializeField] private int _damage;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _bullet = GameObject.FindGameObjectWithTag("Bullet");
        _bulletRigidbody = GetComponent<Rigidbody>();
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Lion>();

        Vector3 _direction = _player.transform.position - transform.position;
        _bulletRigidbody.velocity = new Vector3(_direction.x, 0, _direction.z).normalized * _force;

        transform.rotation = Quaternion.LookRotation(_direction);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        //Lion eh = other.gameObject.GetComponent<Lion>();
        //
        //if (eh)
        //{
        //    Destroy(gameObject);
        //    eh.DoDamage(_damage);
        //}

    }
}
