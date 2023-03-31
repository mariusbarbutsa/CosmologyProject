using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float rotationSpeed = 10f;
    public float rotationSpeed2 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * rotationSpeed2 * Time.deltaTime);

    }
}
