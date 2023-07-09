using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Stats
    protected float _health;
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _attackDamage;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _attackRange;
    [SerializeField] private float _knockback;

    // Other
    private Rigidbody _rb;
    private Vector2 _movement;
    Enemy _enemy;
    PlayerHealthBar _playerHealthBar;

    protected void Start()
    {
        _enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        _playerHealthBar = GetComponent<PlayerHealthBar>();

        // Player Movement
        _rb = GetComponent<Rigidbody>();
        _movement = new Vector2(0, 0);

        _playerHealthBar.SetMaxHealth(_maxHealth);
    }

    protected void Update()
    {
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

    protected void FixedUpdate()
    {
        //move player
        _rb.position += new Vector3(_movement.x, 0, _movement.y) * _speed * Time.fixedDeltaTime;

    }

    protected void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    public void DoDamage(int _damage)
    {
        _rb.AddForce(transform.forward * _knockback);
        _health -= _damage;
        _playerHealthBar.ChangeHealthBar(_health);
    }
}