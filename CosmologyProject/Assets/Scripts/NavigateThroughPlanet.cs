using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavigateThroughPlanet : MonoBehaviour
{
    public PlanetTag planetTag;
    public float scaleSize;
    private Vector3 originalScale;
    public Transform transformList;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.planetChange += MakeActiveBigger;
            Debug.Log("My name is: " + gameObject.name);
        }
        else
        {
            Debug.LogError("GameManager.Instance is null");
        }

        originalScale = transform.localScale;
    }

    void OnDestroy()
    {
        GameManager.Instance.planetChange -= MakeActiveBigger;
    }

    void OnEnable()
    {
        MakeActiveBigger();
    }

    void OnDisable()
    {

    }

    private void MakeActiveBigger()
    {
        Debug.Log("navigate works");

        if (planetTag == GameManager.Instance.activePlanet)
        {
            ScaleAndChangePosition(scaleSize);
        }
    }

    public void ScaleAndChangePosition(float scaleSize)
    {
        transform.localScale = originalScale + Vector3.one * scaleSize;
    }

    public void ResetScaleAndChangePosition()
    {
        transform.localScale = originalScale;
    }

}
