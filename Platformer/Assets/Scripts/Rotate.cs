// Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defining a class named Rotate that inherits from MonoBehaviour
public class Rotate : MonoBehaviour
{
    // Serialized field for rotation speed
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        // Rotating the object around its z-axis based on the speed and frame time
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
