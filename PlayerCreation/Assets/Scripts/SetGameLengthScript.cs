using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameLengthScript : MonoBehaviour
{

    void Awake()
    {
        //default value
        GameManagerScript.GameLength = 15;   
    }

    public void SetGameLength(int length)
    {
        //TODO: set values properly after testing
        GameManagerScript.GameLength = length;
    }
}
