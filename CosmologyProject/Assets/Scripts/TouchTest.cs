using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : TouchBase
{
    // public GameObject snapObject;
    // public float snapDistance = 3f;
    // private bool isDragging;
    private Vector3 offset;


    public override void GotTouched(int fingerID)
    {
        base.GotTouched(fingerID);
        // Do something
        // Debug.Log(gameObject.name);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
    }

    protected override void Update()
    {
        base.Update();
        
        if (isTouching == true)
        {
            // Debug.Log("Touch");
            

            if (GetFingerTouch(out Touch fingerTouch))
            {
                // transform.position += Vector3.right * Time.deltaTime;
                // Debug.Log("An active finger has been found");
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f)) + offset;
                transform.position = newPosition;


            }
        }
    }
}
