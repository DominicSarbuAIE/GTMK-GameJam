using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Stats
    protected int _health;
    public int _maxHealth { get; protected set; }
    public int _speed { get; protected set; }
    public int _damage { get; protected set; }
    public int _knockBack { get; protected set; }

    // Other
    protected Rigidbody _rb;
    private Vector2 _movement;
    public PlayerHealthBar _playerHealthBar;

    protected void Start()
    {
        //_enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        //_playerHealthBar = GetComponent<PlayerHealthBar>();
        _health = _maxHealth;

        // Player Movement
        _rb = GetComponent<Rigidbody>();
        _movement = new Vector2(0, 0);

        // set player healthbar to max health
        //_playerHealthBar.SetMaxHealth(_maxHealth);
    }

    protected void Update()
    {
        // Rotate the player to where the mouse is
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

        //_rb.position += new Vector3(_movement.x, 0, _movement.y) * _speed * Time.fixedDeltaTime;
        _rb.position += new Vector3(_movement.x, 0, _movement.y) * _speed * Time.deltaTime;
    }

    protected void FixedUpdate()
    {
        //move player
        //_rb.position = new Vector3(_movement.x, 0, _movement.y) * _speed * Time.fixedDeltaTime;

    }

    void OnMove(InputValue value)
    {
        Debug.Log("move");
        _movement = value.Get<Vector2>();
    }
}