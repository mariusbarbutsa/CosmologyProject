using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RingRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(50, -65, -66);
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        
    }
}
