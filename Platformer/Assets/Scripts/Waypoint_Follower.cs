// Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting; // This namespace seems unused and can be removed
using UnityEngine;

// Defining a class named Waypoint_Follower that inherits from MonoBehaviour
public class Waypoint_Follower : MonoBehaviour
{
    // Serialized field to hold an array of waypoints
    [SerializeField] private GameObject[] waypoints;

    // Index to keep track of the current waypoint
    private int currentWaypointIndex = 0;

    // Serialized field to set the movement speed of the follower
    [SerializeField] private float speed = 2f;

    private bool movingRight = true;

    // Update is called once per frame
    void Update()
    {
        // Checking if the distance between the follower and the current waypoint is less than 0.1 units
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            // If true, move to the next waypoint
            currentWaypointIndex++;

            // If the current waypoint index exceeds the array length, reset it to 0
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

            // Flip the direction when reaching a waypoint
            FlipDirection();
        }

        // Moving the follower towards the current waypoint using MoveTowards method
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    void FlipDirection()
    {
        // Change the direction of patrolling
        movingRight = !movingRight;

        // Flip the object horizontally
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
