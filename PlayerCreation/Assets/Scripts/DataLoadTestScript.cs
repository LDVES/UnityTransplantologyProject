using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoadTestScript : MonoBehaviour
{
    private GameManagerScript gameManger;

    void Start()
    {
        gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        print(gameManger.GameLength);
    }

}
