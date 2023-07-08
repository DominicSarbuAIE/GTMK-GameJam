using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public KnifeMelee _knife;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _knife._isAttacking)
        {
            Debug.Log("hit");
        }
    }

}
