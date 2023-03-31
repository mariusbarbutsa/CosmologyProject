using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{

    public float rotationSpeedhorizontal = 10f;
    public float rotationSpeedvertical = 10f;

    // public GameObject Planet;


    private void Start()
    {
        

        /*
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y = rotationSpeed * Time.deltaTime;

        transform.localEulerAngles = newRotation;
        */
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * rotationSpeedhorizontal * Time.deltaTime);
        transform.Rotate(Vector3.right * rotationSpeedvertical * Time.deltaTime);
    }
}
