using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _movement;
    private Rigidbody _rb;
    
    private Vector3 direction;
    private float stoppingDistance;
    private bool moveCamera = false;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rb.position += new Vector3(_movement.x, 0, _movement.y) * _speed * Time.deltaTime;
    }
    
    void DetectWalls()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit)) // get player movement direction
        {
            float distance = transform.position.x - hit.point.x;

            if (distance <= stoppingDistance)
            {
                // stop camera from moving
                
            }
            else
            {
                // move camera
            }
        }

        if (moveCamera == true)
        {
            // lerp camera to player
        }
        
    }
    

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }
}