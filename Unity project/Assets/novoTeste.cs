using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novoTeste : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pin")
        {
            Debug.Log("encostou");
            collision.rigidbody.AddForce(transform.forward * 5);

        }
    } */
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "ball")
        {
            Debug.Log("encostou");
            hit.rigidbody.AddForce(transform.forward * 5);

        }
    }
}
