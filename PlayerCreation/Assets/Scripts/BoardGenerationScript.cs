using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerationScript : MonoBehaviour
{
    public GameObject TilePrefab;
    public Transform BoardStart;

    private GameManagerScript gameManager;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        GenerateBoard();
    }

    void GenerateBoard()
    {
        Instantiate(TilePrefab, BoardStart);
    } 

}
