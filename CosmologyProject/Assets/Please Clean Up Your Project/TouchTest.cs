using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : TouchBase
{
    public override void GotTouched(int fingerID)
    {
        base.GotTouched(fingerID);
        // Do something

    }

    protected override void Update()
    {
        base.Update();

        // Whatever you want
        
        if (isTouching == true)
        {
            Touch touch = Input.GetTouch(activeFingerID);
            // Interactive stuff with the specific finger touching this object
            Debug.Log("touch");

        }
    }
}
