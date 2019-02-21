using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int GameLength;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
