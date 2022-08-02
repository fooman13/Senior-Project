using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -9.81f;

    public void Attract(Transform body, bool isdrone, bool isShip)
    {
        Vector3 targetDir = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        if(!isShip)
            body.rotation = Quaternion.FromToRotation(bodyUp, targetDir) * body.rotation;
        if (!isdrone)
            body.GetComponent<Rigidbody>().AddForce(targetDir * gravity);

        else 
            body.GetComponent<Rigidbody>().AddForce(targetDir * -5f);
    }
}
