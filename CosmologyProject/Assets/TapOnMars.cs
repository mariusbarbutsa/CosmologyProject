using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class TapOnMars : MonoBehaviour, IPointerClickHandler
{

    public void Scale(float scaleSize)

    {
        // Get the current scale of the object
        Vector3 currentScale = transform.localScale;

        // Scale the object based on the scaleFactor parameter
        currentScale += Vector3.one * scaleSize;

        // Update the scale of the object
        transform.localScale = currentScale;

    }

    // Function that changes the X and Y position of the object to specific values
    public void ChangePosition(float xPosition, float yPosition)
    {
        // Set the new position of the object with the specific x and y positions
        transform.position = new Vector3(xPosition, yPosition, transform.position.z);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");

        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // Loop through all game objects
        foreach (GameObject obj in allObjects)
        {
            // Check if the game object has the the planets' tags f.x. "Venus"
            if (obj.CompareTag("Mercury") || obj.CompareTag("Venus") || obj.CompareTag("Earth") || obj.CompareTag("Jupiter") || obj.CompareTag("Saturn") || obj.CompareTag("Uranus") || obj.CompareTag("Neptune") || obj.CompareTag("Sun"))
            {
                // Hide the game object
                obj.SetActive(false);
            }
        }

        Scale(5f);
        //ChangePosition(3.6f, 3.6f);


    }



}
