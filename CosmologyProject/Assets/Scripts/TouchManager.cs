using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    // public GameObject affectedGameObject;
    private PlayerInput playerInput;

    private InputAction touchPressAction;
    private InputAction pressA;

    // private string tag = "Mars";

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TapOnPlanet"];
        pressA = playerInput.actions["PressA"];

    }

    private void Start()
    {
        
        
    }

    private void Update()
    {
        if (touchPressAction.WasPerformedThisFrame())
        {
           // Debug.Log("Heyy");
        }
        if (pressA.WasPerformedThisFrame())
        {
            // Debug.Log("Huh");
            // affectedGameObject.SetActive(false);
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Earth");
            foreach (GameObject tagged in taggedObjects)
            {
                tagged.SetActive(false);
            }
        }

        
    }
}