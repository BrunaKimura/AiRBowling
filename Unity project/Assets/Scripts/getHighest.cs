using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHighest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<UnityEngine.UI.Text>().text = "Highest: " + Points.highest;
    }
}
