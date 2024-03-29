using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Camp : MonoBehaviour
{

    public int _radius;
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
        // random number between 5 and 10 to determin how many enemys spawn in camp
        _numberOfEnemys = Random.Range(5,10);

        // for loop goes and spawns the number of enemys
        for (int i = 0; i < _numberOfEnemys; i++)
        {
            // This number will determin which enemy will spawn from the _enemy array
            _enemyNumber = Random.Range(0, _enemys.Length);
            // 1-3 knike guy, 4,5 spear guy and 6 is sniper guy
            _enemy = _enemys[_enemyNumber];
            //random x,y position inside the camps range
            _xLocation = transform.position.x + Random.Range(-6,6);
            _zLocation = transform.position.z + Random.Range(-6,6);
            // make _enemy location = to the random location of x and y
            _enemyLocation = new Vector3(_xLocation, 2, _zLocation);

            // spawn enemy at that location
            Instantiate(_enemy, _enemyLocation, Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
