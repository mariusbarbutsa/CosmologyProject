using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBase : MonoBehaviour
{
    protected int activeFingerID;
    protected bool isTouching = false;

    public virtual void GotTouched(int fingerID)
    {
        activeFingerID = fingerID;
        isTouching = true;
    }


    protected virtual void Update()
    {
        DetectFingerNotTouching();
    }

    private void DetectFingerNotTouching()
    {
        if(isTouching == true)
        {
            Touch touch = Input.GetTouch(activeFingerID);

            if (touch.phase == TouchPhase.Ended)
            {
                isTouching = false;
            }
        }

       /* if(Input.GetMouseButtonUp(0))
        {
            isTouching = false;
        } */
    }
}
