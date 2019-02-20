using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //default value
    public int GameLength;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
