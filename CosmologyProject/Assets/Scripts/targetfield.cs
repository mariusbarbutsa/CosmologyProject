using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetfield : collison
{

    public Vector3 newPosition;

    void Update()
    {

            
            if (isColliding == true)
            {
            TransformPos();
                // PlayerObject.transform.position = newPosition;
            }
           
        
    }

    private void TransformPos()
    {
        Debug.Log("truest");
    }
}
