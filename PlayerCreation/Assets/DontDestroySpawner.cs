using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySpawner : MonoBehaviour
{
    public GameObject gameManager;
    void Awake()
    {
        DontDestroyOnLoad(gameManager);
    }
}
