/*using System.Collections;
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


    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _followSpeed;
    private Vector3 _offset;
    [SerializeField] private Transform _target;
    [SerializeField] private float _maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _target.position;
    }
    
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(_target.position.x, 0, 0);
        RaycastHit hit;

        if (Physics.Raycast(_target.position, _target.position, out hit, _maxDistance))
        {
            // Wall detected within maxDistance
            // Stop camera movement here
            transform.position = Vector3.Lerp(transform.position, targetPosition + _offset, 0);
        }
        else
        {
            // No wall detected within maxDistance
            // Allow camera movement here
            transform.position = Vector3.Lerp(transform.position, targetPosition + _offset, _followSpeed * Time.deltaTime);
        }
    }
}
