using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public TurnManager turnManger;
    public SpawnPlayerScript spawnScript;

    private PlayerMovement currentPlayerMovement;

    public void ShowQuizPanel()
    {
        gameObject.SetActive(true);
    }

    public void HideQuizPanel()
    {
        gameObject.SetActive(false);
    }

    public void GoodAnswer()
    {
        HideQuizPanel();
        //TODO: show good answer popup
        spawnScript.PlayerGameObjectList[turnManger.TurnIndex].GetComponent<PlayerMovement>().FinishWaypointIndex = spawnScript.PlayerGameObjectList[turnManger.TurnIndex].GetComponent<PlayerMovement>().waypointIndex + GameObject.FindGameObjectWithTag("Dice").GetComponent<Dice>().GetDiceResult();
        spawnScript.PlayerGameObjectList[turnManger.TurnIndex].GetComponent<PlayerMovement>().Move();
    }

    public void BadAnswer()
    {
        HideQuizPanel();
        //show popup
        turnManger.NextTurn();
    }
}
