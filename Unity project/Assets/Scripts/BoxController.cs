using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float mult;
    private Rigidbody rb;
    public GameObject WindDirection;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("ball") ){
            // Debug.Log(collision.relativeVelocity);
            var force = transform.position - collision.gameObject.transform.position;
            force.Normalize();
            Debug.Log(force * mult * -1);
            collision.rigidbody.AddForce( force * mult * -1);
        }
    }
}




