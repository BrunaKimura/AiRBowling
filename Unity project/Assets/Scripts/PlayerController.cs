﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    // void FixedUpdate ()
    // {
    //     float moveHorizontal = Input.GetAxis ("Horizontal");
    //     float moveVertical = Input.GetAxis ("Vertical");

    //     Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

    //     rb.AddForce (movement * speed);
    // }

     void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("ball") ){
            Debug.Log(collision.relativeVelocity);
            collision.rigidbody.AddForce( collision.relativeVelocity * 10000 * -1);
        }
    }
}