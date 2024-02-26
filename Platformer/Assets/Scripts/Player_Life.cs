// Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation; // This namespace seems unused and can be removed
using UnityEngine;
using UnityEngine.SceneManagement;

// Defining a class named Player_Life that inherits from MonoBehaviour
public class Player_Life : MonoBehaviour
{
    bool dead = false;

    private void Update()
    {
        if (transform.position.y < -25f && !dead)
        {
            Die();
        }
    }

    // Private variables for Rigidbody2D and Animator
    private Rigidbody2D rb;
    private Animator anim;

    // Serialized field for the death sound effect
    [SerializeField] private AudioSource deathSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        // Getting component references during initialization
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // OnCollisionEnter2D is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checking if the colliding object has the "Trap" tag
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Battle"))
        {
            // If true, call the Die method
            Die();
        }
    }

    // Method to handle player death
    private void Die()
    {
        // Playing the death sound effect
        deathSoundEffect.Play();

        // Disabling the Rigidbody2D's physics behavior
        rb.bodyType = RigidbodyType2D.Static;

        // Triggering the "death" animation state in the Animator
        anim.SetTrigger("death");

        dead = true;
    }

    // Method to restart the current level
    private void RestartLevel()
    {
        // Loading the current scene using SceneManager
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
