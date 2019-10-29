using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;

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

     void OnCollisionEnter(Collision collision)
    {
        
        // Debug.Log(collision.collider.tag);
        if( collision.gameObject.CompareTag("pin") ){
            Debug.Log(collision.relativeVelocity);
            collision.rigidbody.AddForce( collision.relativeVelocity * 100 * -1);
        }
        
        // foreach (ContactPoint contact in collision.contacts)
        // {
        //     Debug.DrawRay(contact.point, contact.normal, Color.white);
        // }
        // if (collision.relativeVelocity.magnitude > 2)
        //     audioSource.Play();
    }
}