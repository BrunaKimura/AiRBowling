using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float mult;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
    

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    //  void OnCollisionEnter(Collision collision)
    // {
    //     if( collision.gameObject.CompareTag("ball") ){
    //         // Debug.Log("Colidiu: " + collision.impulse);
    //         collision.rigidbody.AddForce( Vector3.Scale(transform.forward, new Vector3(-10000, 0, -10000)) );
    //         // collision.rigidbody.AddForce(new Vector3(-10000, 0, -10000));
    //         Debug.Log("transform: " + transform.forward);
    //         // Debug.Log("Velocidade: " + collision.relativeVelocity);
    //         // Debug.Log("impulso: " + collision.impulse);
    //         Debug.Log("Vector: " + Vector3.Scale(collision.impulse, new Vector3(-10000, 0, -10000)));
    //     }
    // }
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