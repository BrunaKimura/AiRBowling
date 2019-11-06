using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFinal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<UnityEngine.UI.Text>().text = "Final result: " + Points.final;
    }
}
