using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _followSpeed = 2;
    private Vector3 _offset;
    [SerializeField] private LayerMask _wall;
    [SerializeField] private Transform _target;
    private float _maxDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void Update()
    {
    }
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(_target.position.x, _target.position.y, _target.position.z);
        RaycastHit hit;

        if (Physics.Raycast(_target.position, _target.position, out hit, _maxDistance, _wall))
        {
            // Wall detected within maxDistance
            // Stop camera movement here
            transform.position = new Vector3(transform.position.x + _offset.x, targetPosition.y + _offset.y, -7.47f);
        }
        else
        {
            // No wall detected within maxDistance
            // Allow camera movement here
            transform.position = Vector3.Lerp(transform.position, targetPosition + _offset, _followSpeed * Time.deltaTime);
        }
    }
}
