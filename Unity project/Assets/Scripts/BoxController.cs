using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.collider.tag);
        if( collision.gameObject.CompareTag("ball") )
        {
            Debug.Log(collision.relativeVelocity);
            collision.rigidbody.AddForce( collision.relativeVelocity * 100 * -1);
        }
    }
}
