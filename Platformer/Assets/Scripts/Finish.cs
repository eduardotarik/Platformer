// Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Defining a class named Finish that inherits from MonoBehaviour
public class Finish : MonoBehaviour
{
    // Private variable to hold the reference to the AudioSource component
    private AudioSource finishSound;

    // Private variable to track whether the level has been completed
    private bool levelCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Getting the AudioSource component attached to the same GameObject
        finishSound = GetComponent<AudioSource>();
    }

    // OnTriggerEnter2D is called when a 2D collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking if the colliding object is named "Player" and the level is not yet completed
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            // Playing the finish sound
            finishSound.Play();

            // Marking the level as completed
            levelCompleted = true;

            // Invoking the CompleteLevel method with a delay of 2 seconds
            Invoke("CompleteLevel", 2f);
        }
    }

    // Method to complete the level by loading the next scene
    private void CompleteLevel()
    {
        // Loading the next scene based on the current active scene's build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
