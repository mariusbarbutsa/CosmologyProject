using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerzone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("triggered");
        }
    }
}
