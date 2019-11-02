using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    private float distToGround;
    private Rigidbody rb;
    public bool fell = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    bool IsGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    void FixedUpdate(){
        if(!rb.isKinematic){
            if (!IsGrounded())
            {
                fell = true;
            }
        }
    }
    bool isFallen(){
        return fell;
    }
}
