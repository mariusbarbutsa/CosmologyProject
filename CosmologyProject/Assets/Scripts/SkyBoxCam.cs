using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxCam : MonoBehaviour

{
    public float rotationSpeed = 1f;
    public float rotationSpeedup = 1f;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * rotationSpeedup * Time.deltaTime);
    }
}