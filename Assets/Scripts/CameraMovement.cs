using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _followSpeed;
    private Vector3 _offset;
    [SerializeField] private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _target.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(_target.position.x, 0, 0);
        transform.position = Vector3.Lerp(transform.position, targetPosition + _offset, _followSpeed * Time.deltaTime);

        //transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _followSpeed * Time.deltaTime);
    }
}