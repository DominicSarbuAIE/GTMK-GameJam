using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public KnifeMelee _knife;
    public Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && _knife._isAttacking)
        {
            Debug.Log("Hit");
            _player.DoDamage(_knife._damage);
        }
    }

}
