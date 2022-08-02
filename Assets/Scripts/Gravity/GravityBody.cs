using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    GravityAttractor planet;

    private void Awake()
    {
        planet = GameObject.FindGameObjectWithTag("Floor").GetComponent<GravityAttractor>();
        GetComponent<Rigidbody>().useGravity = false;    
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
    private void FixedUpdate()
    {
        planet.Attract(transform);
    }
}
