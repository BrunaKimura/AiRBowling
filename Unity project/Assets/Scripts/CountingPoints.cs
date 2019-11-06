using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountingPoints : MonoBehaviour
{
    private int TotalPoints;
    private int turns;
    bool isBackedUp;

    public BoxController box;
    
    // Variables for reset pins
    Vector3[] defaultPosPins;
    Vector3[] defaultScalePins;
    Quaternion[] defaultRotPins;
    Transform[] modelsPins;

    // Variables for reset ball
    Vector3 defaultPosBall;
    Vector3 defaultScaleBall;
    Quaternion defaultRotBall;
    Transform modelBall;

    
    void Start()
    {
        TotalPoints = 0;
        turns = 1;
        isBackedUp = false;
    }
    // FixedUpdate message for physics calculations.
    void Update()
    {  
        if(box.TurnFinished){
            box.TurnFinished = false;
            Debug.Log("Resetting...");
            Reset();
        }
        else
        {
            if(!isBackedUp)
                isBackedUp = true;
                backUpTransform();
        }
    }

    void backUpTransform()
    {
        //Find GameObjects with ball and pin tags
        GameObject[] tempModelsPin = GameObject.FindGameObjectsWithTag("pin");
        GameObject tempModelBall = GameObject.FindGameObjectWithTag("ball");

        //Create pos, scale and rot, Transform array size based on sixe of Objects found
        //Dont need to initialize for ball because it's not an array
        defaultPosPins = new Vector3[tempModelsPin.Length];
        defaultScalePins = new Vector3[tempModelsPin.Length];
        defaultRotPins = new Quaternion[tempModelsPin.Length];

        modelsPins = new Transform[tempModelsPin.Length];

        //Get original the pos, scale and rot of each Object on the transform
        for (int i = 0; i < tempModelsPin.Length; i++)
        {
            modelsPins[i] = tempModelsPin[i].GetComponent<Transform>();
            // Debug.Log("BackUp Log: " + modelsPins[i].name);

            defaultPosPins[i] = modelsPins[i].position;
            defaultScalePins[i] = modelsPins[i].localScale;
            defaultRotPins[i] = modelsPins[i].rotation;
        }
        modelBall = tempModelBall.GetComponent<Transform>();
        defaultPosBall= modelBall.position;
        defaultScaleBall = modelBall.localScale;
        defaultRotBall = modelBall.rotation;
    }

    int resetTransform()
    {   
        int total = 0;
        //Restore the all the original pos, scale and rot  of each GameOBject
        for (int i = 0; i < modelsPins.Length; i++)
        {
            if( Vector3.Distance(modelsPins[i].position, defaultPosPins[i]) > 0.001 )
            {
                // Debug.Log(i + ": " + Vector3.Distance(modelsPins[i].position, defaultPosPins[i]));
                total ++;
            }

            modelsPins[i].position = defaultPosPins[i];
            modelsPins[i].localScale = defaultScalePins[i];
            modelsPins[i].rotation = defaultRotPins[i];
            modelsPins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            modelsPins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        modelBall.position = defaultPosBall;
        modelBall.localScale = defaultScaleBall;
        modelBall.rotation = defaultRotBall;
        modelBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        modelBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        return total;
    }


    void Reset(){
        int currentPoints = resetTransform();
        TotalPoints += currentPoints;
        turns--;
        GameObject turnPoints = this.transform.GetChild(0).gameObject;
        GameObject totalPoints = this.transform.GetChild(1).gameObject;
        GameObject turnsLeft = this.transform.GetChild(2).gameObject;

        if(turns == 0)
        {
            StartCoroutine(waiter(turnPoints));    
        } 
        else
        {
            turnPoints.GetComponent<UnityEngine.UI.Text>().text = "Turn points: " + currentPoints.ToString();
            totalPoints.GetComponent<UnityEngine.UI.Text>().text = "Total points: " + TotalPoints.ToString();
            turnsLeft.GetComponent<UnityEngine.UI.Text>().text = "Turns Left: " + turns.ToString();
            turnPoints.SetActive(true);
            StartCoroutine(waiter(turnPoints));
            isBackedUp = false;
        }
    }  

    IEnumerator waiter(GameObject turnPoints)
    {
        yield return new WaitForSeconds(1);
        turnPoints.SetActive(false);
        if(turns == 0){
            Points.final = TotalPoints;
            Application.LoadLevel(3);
        }
        //Check if game is over

    }
}
