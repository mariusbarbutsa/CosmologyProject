using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : TouchBase
{
    public GameObject snapObject;
    public float snapDistance = 3f;
    private bool isDragging;
    private Vector3 offset;
    // private float zCoord = 0f;


    public override void GotTouched(int fingerID)
    {
        base.GotTouched(fingerID);
        // Do something
        Debug.Log(gameObject.name);
    }

    protected override void Update()
    {
        base.Update();
        
        if (isTouching == true)
        {
            Debug.Log("Touch");

            if (GetFingerTouch(out Touch fingerTouch))
            {
                // transform.position += Vector3.right * Time.deltaTime;
                // An active finger has been found


                /* if (Input.touchCount > 0)
                 {
                     Touch touch = Input.GetTouch(activeFingerID);
                     Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0);

                     if (touch.phase == TouchPhase.Began)
                     {
                         zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                         offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(touchPos);
                         isDragging = true;
                     }
                     else if (touch.phase == TouchPhase.Moved && isDragging)
                     {
                         transform.position = Camera.main.ScreenToWorldPoint(touchPos) + offset;
                         if (Vector3.Distance(transform.position, snapObject.transform.position) <= snapDistance)
                         {
                             transform.position = snapObject.transform.position;
                         }
                     }
                     else if (touch.phase == TouchPhase.Ended && isDragging)
                     {
                         isDragging = false;
                         if (Vector3.Distance(transform.position, snapObject.transform.position) <= snapDistance)
                         {
                             transform.position = snapObject.transform.position;
                         }
                     }

                 }
                */

            }
        }
    }
}
