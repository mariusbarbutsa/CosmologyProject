using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerzone : MonoBehaviour
{
    public string triggerTag = "Trigger zone";
    public Vector3 newPosition = new Vector3(0, 1, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            gameObject.transform.position = newPosition;
        }
    }
}
