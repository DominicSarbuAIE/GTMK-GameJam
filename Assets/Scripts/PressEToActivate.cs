using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PressEToActivate : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private GameObject[] _gameObjects;

    private Transform _player;
    private float _distance;

    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
        _distance = Vector3.Distance(transform.position, _player.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject obj in _gameObjects)
            {
                obj.GetComponent<Animator>().SetTrigger("Activate");
            }
        }
    }
}
