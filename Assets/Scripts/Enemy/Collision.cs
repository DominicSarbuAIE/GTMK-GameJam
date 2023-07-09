using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public KnifeMelee _knife;
    [SerializeField] private Player _player;

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && _knife._isAttacking)
        {
            Debug.Log("Hit");
            _player.DoDamage(_knife._damage);
        }
    }

}
