using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int diceSideThrown;
    public int Player1StartWaypoint = 0;
    public int Player2StartWaypoint = 0;

    public PlayerMovement player1Movement;
    public PlayerMovement player2Movement;

    void Start()
    {

        player1Movement.moveAllowed = false;
        player2Movement.moveAllowed = false;
    }

    void Update()
    {
        if (player1Movement.waypointIndex > Player1StartWaypoint + diceSideThrown)
        {
            player1Movement.moveAllowed = false;
            Player1StartWaypoint = player1Movement.waypointIndex - 1;
        }

        if (player2Movement.waypointIndex > Player2StartWaypoint + diceSideThrown)
        {
            player2Movement.moveAllowed = false;
            Player2StartWaypoint = player1Movement.waypointIndex -1;
        }

        if (player1Movement.waypointIndex == player1Movement.waypoints.Length)
        {
            print("Player 1 wins!");
        }

        if (player2Movement.waypointIndex == player2Movement.waypoints.Length)
        {
            print("Player 2 wins!");
        }

    }

    public void MovePlayer(int playerToMove)
    {
        switch (playerToMove)
        {
            case 1:
                player1Movement.moveAllowed = true;
                break;
            case 2:
                player2Movement.moveAllowed = true;
                break;
        }
    }
}
