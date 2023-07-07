using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] private int _spawnDaly;
    [SerializeField] private Rigidbody _enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyDelay());
    }

    public IEnumerator SpawnEnemyDelay()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            Rigidbody enemnySpawn = Instantiate(_enemy, transform.position, transform.rotation);
            yield return new WaitForSeconds(_spawnDaly);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
