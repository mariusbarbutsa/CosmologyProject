using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class collison : MonoBehaviour
{
    
    
    protected bool isColliding;

    // Rigidbody m_Rigidbody;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger zone"))
        {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger zone"))
        {
            isColliding = false;
        }
    }

    IEnumerator CheckCollisions()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            GameObject[] PlayerObjects = GameObject.FindGameObjectsWithTag("Player");
            bool collisionDetected = false;
            foreach (GameObject PlayerObject in PlayerObjects)
            {
                if (isColliding && PlayerObject.GetComponent<Collider>().bounds.Intersects(gameObject.GetComponent<Collider>().bounds))
                {
                    collisionDetected = true;
                    // m_Rigidbody = GetComponent<Rigidbody>();
                    // PlayerObject.transform.position = newPosition;
                    // PlayerObject.transform.position = transform.position + new Vector3(0,0,0);
                    // myTransform = GetComponent<Transform>();
                    // myTransform.position += new Vector3(0, 0, 0);

                    break;
                }
            }
            Debug.Log("Collision detected: " + collisionDetected);
        }
    }

    void Start()
    {
        StartCoroutine(CheckCollisions());
    }
}
