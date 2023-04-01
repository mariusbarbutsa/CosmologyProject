using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : TouchBase
{
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
                transform.position += Vector3.right * Time.deltaTime;
                // An active finger has been found
            }
        }
    }
}
