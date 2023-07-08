using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _position = new Vector3();
    private Rigidbody _rb;
    private Vector2 _movement;
    [SerializeField] private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _movement = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move player
        _rb.position += new Vector3(_movement.x, 0, _movement.y) * _speed * Time.deltaTime;

        Mouse mouse = Mouse.current;
        Ray camRay = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float dist;
        if (plane.Raycast(camRay, out dist))
        {         
            Vector3 t = camRay.GetPoint(dist / 1.01f);
            Vector3 dir = t - transform.position;
            float rot = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, rot, 0.0f); // Body rotation.
        }

    }

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }
}

