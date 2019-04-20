using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public Animator PlayerAnimator;
    public float Speed = 1f;
    public int FinishWaypointIndex = 0;
    public int waypointIndex = 0;

    private bool moveAllowed = false;

    //if doesn't work set in spawn
    private GameOver gameOverScript;

    void Update()
    {
        if (moveAllowed)
            Move();
    }

    public void Move()
    {

        moveAllowed = true;
        PlayerAnimator.SetBool("IsMoving", true);

        if (waypointIndex < waypoints.Count)
        {
            if (waypointIndex != FinishWaypointIndex)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, waypoints[waypointIndex].transform.position) <= 0.01f)
                {
                    waypointIndex += 1;
                }
            }
            else
            {
                moveAllowed = false;
                PlayerAnimator.SetBool("IsMoving", false);
                GameObject.FindGameObjectWithTag("GameBoard").GetComponent<TurnManager>().NextTurn();
            }
        }
        //Game Over
        else
        {
            PlayerAnimator.SetBool("IsMoving", false);
            moveAllowed = false;
            gameOverScript = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOver>();
            gameOverScript.ShowGameOver();
        }
    }
}
