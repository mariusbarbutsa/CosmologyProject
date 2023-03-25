using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class TapOnPlanet : MonoBehaviour, IPointerClickHandler
{
    public PlanetState state = PlanetState.Norm;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
        state = PlanetState.Mars;

    }

    private void Update()
    {
        if (state == PlanetState.Mars)
        {
            
            if (tag.Equals("Mars") )
            {
                Debug.Log("mars");

            }
            else
            {
                gameObject.SetActive(false);
            }

            /* GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Earth");
            foreach (GameObject tagged in taggedObjects)
            {
                tagged.SetActive(false);
            }
            */
                /*while (tag.Equals("Mars") == false)
                {
                    gameObject.SetActive(false);
                }
                */
        }
    }

    public enum PlanetState
    {
        Norm,
        Mars,
        Mercury,
        Earth
    }
}
