using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    public GameObject gameobject;
    private PlayerInput playerInput;

    private InputAction touchPressAction;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TapOnPlanet"];

    }

    private void Update()
    {
        if (touchPressAction.WasPerformedThisFrame())
        {
            Debug.Log("Heyy");
        }
    }
}