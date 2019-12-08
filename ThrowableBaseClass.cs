using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableBaseClass : MonoBehaviour
{
    public float fuseTime = 5;
    Rigidbody rb;
    public float throwForce;
    public Vector3 direction;
    public virtual void Initiation()
    {
        rb = GetComponent<Rigidbody>();
        //Vector3 grenadeDirection = new Vector3(0, 0, throwForce);
        //rb.AddForce(grenadeDirection);
       
    }
    public void ThrowAndDie()
    {
        rb.AddForce(direction * throwForce);
    }
}
