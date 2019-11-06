using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float mult;
    private Rigidbody rb;
    public WindDirection wind;
    public bool TurnFinished = false;
    private bool hasCollide = false;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("ball") ){
            if(hasCollide == false)
            {
                var force = transform.position - collision.gameObject.transform.position;
                force.Normalize();
                Debug.Log(force * mult * -1);
                Vector3 result = (force + wind.getWind()) * mult * -1;
                collision.rigidbody.AddForce( force*mult*-1 );
                StartCoroutine(waiter());
            }

        }
    }
    IEnumerator waiter()
    {
        //Wait for 10 seconds
        Debug.Log("Beginning sleep");
        yield return new WaitForSeconds(5);
        TurnFinished = true;
        hasCollide = true;
        Debug.Log("Stopping sleep");
    }
}




