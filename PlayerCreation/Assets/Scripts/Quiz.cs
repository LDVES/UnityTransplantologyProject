using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public TurnManager turnManger;
    public SpawnPlayerScript spawnScript;
    public TogglePanel toggleScript;

    private PlayerMovement currentPlayerMovement;

    public void GoodAnswer()
    {
        toggleScript.HideQuizPanel();
        //TODO: show good answer popup
        spawnScript.PlayerGameObjectList[turnManger.TurnIndex].GetComponent<PlayerMovement>().FinishWaypointIndex = spawnScript.PlayerGameObjectList[turnManger.TurnIndex].GetComponent<PlayerMovement>().waypointIndex + GameObject.FindGameObjectWithTag("Dice").GetComponent<Dice>().GetDiceResult();
        spawnScript.PlayerGameObjectList[turnManger.TurnIndex].GetComponent<PlayerMovement>().Move();
    }

    public void BadAnswer()
    {
        toggleScript.HideQuizPanel();
        //show popup
        turnManger.NextTurn();
    }
}