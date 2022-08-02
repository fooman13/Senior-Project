using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    GravityAttractor planet;
    public bool isdrone;
    public bool isShip;

    private void Awake()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        GetComponent<Rigidbody>().useGravity = false;
        if (!isShip)    
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
    private void FixedUpdate()
    {
        planet.Attract(transform, isdrone, isShip);
    }
}
