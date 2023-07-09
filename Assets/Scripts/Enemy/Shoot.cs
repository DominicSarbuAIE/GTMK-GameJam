using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _timeTillFire;
    [SerializeField] private float _fireRate;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _firePosition;
    [SerializeField] private Transform _target;
    private float _distance;
    [SerializeField] private float _fireDistanceMin;
    [SerializeField] private float _fireDistanceMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(_target.position, transform.position);

        if (_distance > _fireDistanceMin && _distance < _fireDistanceMax)
        {
            Fire();
        }
    }

    public void Fire()
    {
        if(_timeTillFire <= 0f)
        {
            Instantiate(_projectile, _firePosition.position, _firePosition.rotation);
            _timeTillFire = _fireRate;
        }
        else
        {
            _timeTillFire -= Time.deltaTime;
        }
    }
}
