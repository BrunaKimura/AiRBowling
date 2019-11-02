using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnCLick : MonoBehaviour
{
    public void loadScene(int mode)
    {
        Application.LoadLevel(mode);
    }
}
