using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison : MonoBehaviour
{
    [SerializeField] private int _damage;
    void OnTriggerEnter(Collider other)
    {
        //Lion eh = other.gameObject.GetComponent<Lion>();
        //
        //if (eh)
        //{
        //    Debug.Log("hit");
        //    eh.DoDamage(_damage);
        //}

    }
}
