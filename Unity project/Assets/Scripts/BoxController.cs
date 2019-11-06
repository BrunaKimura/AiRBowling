using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float mult;
    private Rigidbody rb;
    public WindDirection wind;
    public bool TurnFinished = false;
    private bool hasCollide = false;
    public GameObject toggle;

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
                if(toggle.GetComponent<Toggle>().isOn){
                    collision.rigidbody.AddForce( (force+wind.getWind()) * mult * -1 );
                    Debug.Log((force+wind.getWind()) * mult * -1 );
                }
                else{
                    collision.rigidbody.AddForce( force*mult*-1 );
                }
                // Vector3 result = (force + wind.getWind()) * mult * -1;
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




