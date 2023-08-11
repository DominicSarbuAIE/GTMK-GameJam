using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Camp : MonoBehaviour
{

    public int _radius; // Unused
    private int _numberOfEnemys;
    private float _xLocation;
    private float _zLocation;
    private int _enemyNumber;
    private GameObject _enemy;
    [SerializeField] private GameObject[] _enemys;
    private Vector3 _enemyLocation;


    // Start is called before the first frame update
    void Start()
    {
        _numberOfEnemys = Random.Range(3,7);

        for (int i = 0; i < _numberOfEnemys; i++)
        {
            _enemyNumber = Random.Range(0, _enemys.Length);
            _enemy = _enemys[_enemyNumber];
            _xLocation = transform.position.x + Random.Range(-6,6);
            _zLocation = transform.position.z + Random.Range(-6,6);
            _enemyLocation = new Vector3(_xLocation, 2, _zLocation);

            Instantiate(_enemy, _enemyLocation, Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
