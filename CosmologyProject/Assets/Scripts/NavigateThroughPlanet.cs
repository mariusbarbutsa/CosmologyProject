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
        }
        else
        {
            Debug.LogError("GameManager.Instance is null");
        }
    }

    void OnDestroy()
    {
        GameManager.Instance.planetChange -= MakeActiveBigger;
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

    private void MakeActiveBigger()
    {
        Debug.Log("navigate works");

        for (int i = 0; i < transformList.childCount; i++)
        {
            if (transformList.GetChild(i).CompareTag(GameManager.Instance.activePlanet.ToString()))
            {
                ScaleAndChangePosition(scaleSize);
            }


        }
    }

    public void ScaleAndChangePosition(float scaleSize)
    {

        Vector3 currentScale = transform.localScale;
        Vector3 targetScale = currentScale + Vector3.one * scaleSize;
        transform.localScale = targetScale;
    }

}
