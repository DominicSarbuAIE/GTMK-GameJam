using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    public Camp _camp;
    [SerializeField] private Transform _campsPos;
    [SerializeField] private Transform _enemyPos;
    public bool _enemyInCamp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyInCamp)
        {
            StartCoroutine(MoveInCamp());
        }
    }

    public void MoveToCamp()
    {
        Vector3 enemyPos = new Vector3(_enemyPos.position.x, transform.position.y, _enemyPos.position.z);
        Vector3 _campPosition = new Vector3(_campsPos.position.x, transform.position.y, _campsPos.position.z);

        if (enemyPos.x > _campPosition.x + _camp._radius || enemyPos.x < _campPosition.x + _camp._radius)
        {
            if (enemyPos.z > _campPosition.z + _camp._radius || enemyPos.z < _campPosition.z + _camp._radius)
            {
                transform.position = Vector3.MoveTowards(transform.position, _campsPos.position, _speed * Time.deltaTime);
            }
        }
        _enemyInCamp = true;
    }

    private IEnumerator MoveInCamp()
    {

        Vector3 enemyPos = new Vector3(_enemyPos.position.x, transform.position.y, _enemyPos.position.z);
        Vector3 _campPosition = new Vector3(_campsPos.position.x, transform.position.y, _campsPos.position.z);

        yield return new WaitForSeconds(5f);

        if (enemyPos.x < _campPosition.x + _camp._radius || enemyPos.x > _campPosition.x + _camp._radius)
        {
            if (enemyPos.z < _campPosition.z + _camp._radius || enemyPos.z > _campPosition.z + _camp._radius)
            {
                float _xPos = Random.Range(-6, 6);
                float _zPos = Random.Range(-6, 6);

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(_xPos, 0, _zPos), _speed * Time.deltaTime);
            }
        }
    }
}
