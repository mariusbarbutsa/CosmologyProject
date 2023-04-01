using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBase : MonoBehaviour
{
    protected int activeFingerID;
    public bool isTouching = false;

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
            if(GetFingerTouch(out Touch fingerTouch))
            {
                if (fingerTouch.phase == TouchPhase.Ended)
                {
                    isTouching = false;
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            isTouching = false;
        }
    }

    public bool GetFingerTouch(out Touch fingerTouch)
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.fingerId == activeFingerID)
            {
                fingerTouch = touch;
                return true;
            }
        }

        fingerTouch = new Touch();

        if (activeFingerID == -1)
        {
            return true;
        }

        return false;
    }
}
