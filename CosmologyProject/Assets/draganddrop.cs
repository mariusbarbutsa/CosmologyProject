using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.InputSystem;

public class draganddrop : MonoBehaviour
{

    private InputAction screenPos;
    private InputAction press;

    public Camera Camera;

    private Vector3 curScreenPos;
    private bool isDragging;

    private Vector3 WorldPos
    {
        get
        {
            
            float z = Camera.WorldToScreenPoint(transform.position).z;
            return Camera.ScreenToWorldPoint(curScreenPos + new Vector3(0, 0, z));
        }
    }

    private bool isClickedOn
    {
        get
        {

            Ray ray = Camera.ScreenPointToRay(curScreenPos);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                return hit.transform == transform;
            }
            return false;
        }
    }

    private void Awake()
    {
        screenPos.Enable();
        press.Enable();
        screenPos.performed += context => { curScreenPos = context.ReadValue<Vector2>(); };
        press.performed += _ => { if(isClickedOn) StartCoroutine(Drag()); };
        press.canceled += _ => { isDragging = false; };
         
    }

    private IEnumerator Drag()
    {
        isDragging = true;
        Vector3 offset = transform.position - WorldPos;
        while(isDragging)
        {
            transform.position = WorldPos + offset;
            yield return null;
        }
    }
}
