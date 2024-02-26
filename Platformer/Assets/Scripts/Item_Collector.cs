// Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Defining a class named Item_Collector that inherits from MonoBehaviour
public class Item_Collector : MonoBehaviour
{
    // Private variable to store the number of collected cherries
    private int cherries = 0;

    // Serialized field for the Text component displaying the collected cherries count
    [SerializeField] private Text cherriesText;

    // Serialized field for the sound effect played when collecting items
    [SerializeField] private AudioSource collectionSoundEffect;

    // OnTriggerEnter2D is called when a 2D collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking if the colliding object has the "Cherry" tag
        if (collision.gameObject.CompareTag("Cherry"))
        {
            // Playing the collection sound effect
            collectionSoundEffect.Play();

            // Destroying the collected cherry GameObject
            Destroy(collision.gameObject);

            // Incrementing the cherries count
            cherries++;

            // Updating the displayed cherries count in the UI
            cherriesText.text = "Cherries: " + cherries;
        }
    }
}
