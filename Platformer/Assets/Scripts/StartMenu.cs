// Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Defining a class named NewBehaviourScript that inherits from MonoBehaviour
public class NewBehaviourScript : MonoBehaviour
{
    // Public method to start the game
    public void StartGame()
    {
        // Get the current active scene's build index and load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
