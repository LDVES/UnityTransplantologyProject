using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int TurnIndex = 0;
    public Dice dice;

    private GameManagerScript gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    public void NextTurn()
    {
        TurnIndex ++;
        if (TurnIndex > gameManager.PlayerList.Count - 1)
            TurnIndex = 0;

        dice.isDiceRollAllowed = true;
    }
}
