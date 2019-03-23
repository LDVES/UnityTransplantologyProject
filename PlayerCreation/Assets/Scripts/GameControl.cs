using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int diceSideThrown;
    public int Player1StartWaypoint = 0;

    public PlayerMovement player1Movement;

    //void Start()
    //{
    //    player1Movement.moveAllowed = false;
    //}

    //void Update()
    //{
    //    if (player1Movement.waypointIndex > Player1StartWaypoint + diceSideThrown)
    //    {
    //        player1Movement.moveAllowed = false;
    //        Player1StartWaypoint = player1Movement.waypointIndex - 1;
    //    }

    //}
}
