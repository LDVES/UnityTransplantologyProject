using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int TurnIndex = 0;
    public GameManagerScript gameManager;
    public Dice dice;

    public void NextTurn()
    {
        TurnIndex ++;
        if (TurnIndex > gameManager.PlayerList.Count)
            TurnIndex = 0;

        dice.isDiceRollAllowed = true;
    }
}
