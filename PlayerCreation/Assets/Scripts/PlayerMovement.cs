using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float Speed = 1f;
    public int waypointIndex = 0;
    public bool moveAllowed = false;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        if (moveAllowed)
            Move();
    }

    private void Move()
    {
        print(waypointIndex);
        print(Vector2.Distance(transform.position, waypoints[waypointIndex].transform.position));
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, waypoints[waypointIndex].transform.position) <= 0.01f)
            {
                waypointIndex += 1;
            }
            
        }
    }
}
