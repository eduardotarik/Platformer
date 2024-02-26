// Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defining a class named Sticky_Platform that inherits from MonoBehaviour
public class Sticky_Platform : MonoBehaviour
{
    // OnTriggerEnter2D is called when a 2D collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking if the colliding object is named "Player"
        if (collision.gameObject.name == "Player")
        {
            // Setting the platform as the parent of the player object
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // OnTriggerExit2D is called when a 2D collider exits the trigger collider attached to this GameObject
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Checking if the colliding object is named "Player"
        if (collision.gameObject.name == "Player")
        {
            // Removing the platform as the parent of the player object (setting it to null)
            collision.gameObject.transform.SetParent(null);
        }
    }
}
