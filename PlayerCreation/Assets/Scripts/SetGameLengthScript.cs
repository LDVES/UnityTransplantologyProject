using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameLengthScript : MonoBehaviour
{
    public GameManagerScript GameManager;

    void Awake()
    {
        //default value
        GameManager.GameLength = 10;   
    }

    public void SetGameLength(int length)
    { 
        //TODO: set values properly after testing
        GameManager.GameLength = length;
    }
}
