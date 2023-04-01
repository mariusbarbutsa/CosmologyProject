using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputHandler : MonoBehaviour
{
    void Update()
    {
        foreach(Touch t in Input.touches)
        {
            if(t.phase == TouchPhase.Began)
            {
                TouchBase touchBase = GetTouchObject(t.position);
                if(touchBase != null)
                {
                    touchBase.GotTouched(t.fingerId);
                }
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            TouchBase touchBase = GetTouchObject(Input.mousePosition);
            if (touchBase != null)
            {
                touchBase.GotTouched(-1);
            }
        }
    }

    private TouchBase GetTouchObject(Vector2 inputPosition)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(inputPosition);
        RaycastHit[] objectsTouched = Physics.RaycastAll(worldPos, Camera.main.transform.forward, 100f);
        if (objectsTouched.Length > 0)
        {
            GameObject objectTouched = objectsTouched[0].collider.gameObject;
            TouchBase touchBase = objectTouched.GetComponent<TouchBase>();
            if (touchBase != null)
            {
                return touchBase;
            }
        }

        return null;
    }
}
